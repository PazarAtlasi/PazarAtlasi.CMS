using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using PazarAtlasi.CMS.Persistence.Context;
using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Enums;
using PazarAtlasi.CMS.Services.Interfaces;

namespace PazarAtlasi.CMS.Controllers
{
    /// <summary>
    /// Controller for managing the Agent Marketplace
    /// Handles agent listing, details, subscriptions, and management
    /// </summary>
    public class AgentMarketplaceController : Controller
    {
        private readonly PazarAtlasiDbContext _context;
        private readonly IN8nService _n8nService;

        public AgentMarketplaceController(PazarAtlasiDbContext context, IN8nService n8nService)
        {
            _context = context;
            _n8nService = n8nService;
        }

        /// <summary>
        /// Main marketplace view - shows all available agents in a grid
        /// </summary>
        public async Task<IActionResult> Index(AgentCategory? category = null, AgentType? type = null, string search = null)
        {
            var query = _context.Agents
                .Include(a => a.Pricings.Where(p => p.IsActive))
                .Include(a => a.Capabilities.Where(c => c.IsKeyFeature))
                .Where(a => a.IsActive);

            // Apply filters
            if (category.HasValue)
                query = query.Where(a => a.Category == category.Value);

            if (type.HasValue)
                query = query.Where(a => a.Type == type.Value);

            if (!string.IsNullOrEmpty(search))
                query = query.Where(a => a.Name.Contains(search) || a.Description.Contains(search));

            var agents = await query
                .OrderByDescending(a => a.IsFeatured)
                .ThenBy(a => a.SortOrder)
                .ThenBy(a => a.Name)
                .ToListAsync();

            ViewBag.Categories = Enum.GetValues<AgentCategory>().Cast<AgentCategory>();
            ViewBag.Types = Enum.GetValues<AgentType>().Cast<AgentType>();
            ViewBag.CurrentCategory = category;
            ViewBag.CurrentType = type;
            ViewBag.CurrentSearch = search;

            return View(agents);
        }

        /// <summary>
        /// Agent detail page with capabilities, pricing options, and subscription
        /// </summary>
        public async Task<IActionResult> Details(int id)
        {
            var agent = await _context.Agents
                .Include(a => a.Pricings.Where(p => p.IsActive))
                .Include(a => a.Capabilities)
                .Include(a => a.Integrations.Where(i => i.IsActive))
                .FirstOrDefaultAsync(a => a.Id == id && a.IsActive);

            if (agent == null)
                return NotFound();

            return View(agent);
        }

        /// <summary>
        /// Subscribe to an agent with selected pricing
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Subscribe(int agentId, int pricingId, int? agentCount = null)
        {
            // TODO: Get current user ID from authentication
            int currentUserId = 1; // Placeholder

            var agent = await _context.Agents.FindAsync(agentId);
            var pricing = await _context.AgentPricings.FindAsync(pricingId);

            if (agent == null || pricing == null || !agent.IsActive || !pricing.IsActive)
                return BadRequest("Invalid agent or pricing selection");

            // Check if user already has an active subscription
            var existingSubscription = await _context.AgentSubscriptions
                .FirstOrDefaultAsync(s => s.UserId == currentUserId && 
                                         s.AgentId == agentId && 
                                         s.Status == SubscriptionStatus.Active);

            if (existingSubscription != null)
                return BadRequest("You already have an active subscription for this agent");

            // Create new subscription
            var subscription = new AgentSubscription
            {
                AgentId = agentId,
                UserId = currentUserId,
                AgentPricingId = pricingId,
                StartDate = DateTime.UtcNow,
                Status = SubscriptionStatus.Active,
                AgentCount = agentCount,
                CurrentUsage = 0,
                LastUsageReset = DateTime.UtcNow,
                NextBillingDate = pricing.Type == PricingType.Monthly ? DateTime.UtcNow.AddMonths(1) : null
            };

            _context.AgentSubscriptions.Add(subscription);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"Successfully subscribed to {agent.Name}!";
            return RedirectToAction(nameof(MySubscriptions));
        }

        /// <summary>
        /// User's active subscriptions and usage
        /// </summary>
        public async Task<IActionResult> MySubscriptions()
        {
            // TODO: Get current user ID from authentication
            int currentUserId = 1; // Placeholder

            var subscriptions = await _context.AgentSubscriptions
                .Include(s => s.Agent)
                .Include(s => s.Pricing)
                .Where(s => s.UserId == currentUserId)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            return View(subscriptions);
        }

        /// <summary>
        /// Cancel a subscription
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CancelSubscription(int subscriptionId)
        {
            // TODO: Get current user ID from authentication
            int currentUserId = 1; // Placeholder

            var subscription = await _context.AgentSubscriptions
                .FirstOrDefaultAsync(s => s.Id == subscriptionId && s.UserId == currentUserId);

            if (subscription == null)
                return NotFound();

            subscription.Status = SubscriptionStatus.Cancelled;
            subscription.EndDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            TempData["Success"] = "Subscription cancelled successfully";
            return RedirectToAction(nameof(MySubscriptions));
        }

        /// <summary>
        /// Usage logs for a specific subscription
        /// </summary>
        public async Task<IActionResult> UsageLogs(int subscriptionId, int page = 1, int pageSize = 20)
        {
            // TODO: Get current user ID from authentication
            int currentUserId = 1; // Placeholder

            var subscription = await _context.AgentSubscriptions
                .Include(s => s.Agent)
                .FirstOrDefaultAsync(s => s.Id == subscriptionId && s.UserId == currentUserId);

            if (subscription == null)
                return NotFound();

            var logs = await _context.AgentUsageLogs
                .Include(l => l.Integration)
                .Where(l => l.AgentSubscriptionId == subscriptionId)
                .OrderByDescending(l => l.ExecutionTime)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalCount = await _context.AgentUsageLogs
                .CountAsync(l => l.AgentSubscriptionId == subscriptionId);

            ViewBag.Subscription = subscription;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = totalCount;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            return View(logs);
        }

        // ===== ADMIN MANAGEMENT ACTIONS =====

        /// <summary>
        /// Admin: Manage all agents
        /// </summary>
        public async Task<IActionResult> Manage()
        {
            var agents = await _context.Agents
                .Include(a => a.Pricings)
                .Include(a => a.Capabilities)
                .Include(a => a.Subscriptions)
                .OrderBy(a => a.SortOrder)
                .ThenBy(a => a.Name)
                .ToListAsync();

            return View(agents);
        }

        /// <summary>
        /// Admin: Create new agent
        /// </summary>
        public IActionResult Create()
        {
            ViewBag.AgentTypes = Enum.GetValues<AgentType>().Cast<AgentType>();
            ViewBag.AgentCategories = Enum.GetValues<AgentCategory>().Cast<AgentCategory>();
            ViewBag.ExecutionTypes = Enum.GetValues<AgentExecutionType>().Cast<AgentExecutionType>();
            
            return View(new Agent());
        }

        /// <summary>
        /// Admin: Create new agent (POST)
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Agent agent, List<AgentIntegration> integrations)
        {
            if (ModelState.IsValid)
            {
                // Process integrations
                if (integrations != null && integrations.Any())
                {
                    foreach (var integration in integrations.Where(i => !string.IsNullOrEmpty(i.Name)))
                    {
                        // Convert form data to JSON configuration
                        var configJson = ProcessIntegrationConfiguration(integration);
                        integration.ConfigurationJson = configJson;
                        integration.Agent = agent;
                        agent.Integrations.Add(integration);
                    }
                }

                _context.Agents.Add(agent);
                await _context.SaveChangesAsync();

                TempData["Success"] = $"Agent '{agent.Name}' created successfully with {agent.Integrations.Count} integration(s)!";
                return RedirectToAction(nameof(Manage));
            }

            ViewBag.AgentTypes = Enum.GetValues<AgentType>().Cast<AgentType>();
            ViewBag.AgentCategories = Enum.GetValues<AgentCategory>().Cast<AgentCategory>();
            ViewBag.ExecutionTypes = Enum.GetValues<AgentExecutionType>().Cast<AgentExecutionType>();
            
            return View(agent);
        }

        /// <summary>
        /// Process integration configuration from form data to JSON
        /// </summary>
        private string ProcessIntegrationConfiguration(AgentIntegration integration)
        {
            var config = new Dictionary<string, object>();

            // Get configuration from Request.Form based on integration type
            var formKeys = Request.Form.Keys.Where(k => k.Contains($"ConfigurationJson."));
            
            foreach (var key in formKeys)
            {
                var configKey = key.Split('.').Last();
                var value = Request.Form[key].ToString();
                
                if (!string.IsNullOrEmpty(value))
                {
                    // Try to parse numbers
                    if (int.TryParse(value, out int intValue))
                    {
                        config[configKey] = intValue;
                    }
                    else if (decimal.TryParse(value, out decimal decimalValue))
                    {
                        config[configKey] = decimalValue;
                    }
                    else if (bool.TryParse(value, out bool boolValue))
                    {
                        config[configKey] = boolValue;
                    }
                    else
                    {
                        config[configKey] = value;
                    }
                }
            }

            return JsonSerializer.Serialize(config, new JsonSerializerOptions 
            { 
                WriteIndented = true 
            });
        }

        /// <summary>
        /// Admin: Edit agent
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            var agent = await _context.Agents
                .Include(a => a.Pricings)
                .Include(a => a.Capabilities)
                .Include(a => a.Integrations)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (agent == null)
                return NotFound();

            ViewBag.AgentTypes = Enum.GetValues<AgentType>().Cast<AgentType>();
            ViewBag.AgentCategories = Enum.GetValues<AgentCategory>().Cast<AgentCategory>();
            ViewBag.ExecutionTypes = Enum.GetValues<AgentExecutionType>().Cast<AgentExecutionType>();

            return View(agent);
        }

        /// <summary>
        /// Admin: Edit agent (POST)
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Agent agent)
        {
            if (id != agent.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agent);
                    await _context.SaveChangesAsync();
                    
                    TempData["Success"] = "Agent updated successfully!";
                    return RedirectToAction(nameof(Manage));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AgentExists(agent.Id))
                        return NotFound();
                    throw;
                }
            }

            ViewBag.AgentTypes = Enum.GetValues<AgentType>().Cast<AgentType>();
            ViewBag.AgentCategories = Enum.GetValues<AgentCategory>().Cast<AgentCategory>();
            ViewBag.ExecutionTypes = Enum.GetValues<AgentExecutionType>().Cast<AgentExecutionType>();

            return View(agent);
        }

        /// <summary>
        /// Admin: Delete agent
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var agent = await _context.Agents.FindAsync(id);
            if (agent != null)
            {
                agent.IsDeleted = true; // Soft delete
                await _context.SaveChangesAsync();
                
                TempData["Success"] = "Agent deleted successfully!";
            }

            return RedirectToAction(nameof(Manage));
        }

        /// <summary>
        /// Admin: Agent analytics and statistics
        /// </summary>
        public async Task<IActionResult> Analytics()
        {
            var stats = new
            {
                TotalAgents = await _context.Agents.CountAsync(a => a.IsActive),
                TotalSubscriptions = await _context.AgentSubscriptions.CountAsync(s => s.Status == SubscriptionStatus.Active),
                TotalUsage = await _context.AgentUsageLogs.CountAsync(),
                PopularAgents = await _context.AgentSubscriptions
                    .Include(s => s.Agent)
                    .Where(s => s.Status == SubscriptionStatus.Active)
                    .GroupBy(s => s.Agent)
                    .Select(g => new { Agent = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .Take(5)
                    .ToListAsync()
            };

            return View(stats);
        }

        // ===== AGENT EXECUTION API =====

        /// <summary>
        /// Execute an agent via its configured integrations
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> ExecuteAgent(int agentId, int subscriptionId, [FromBody] object inputData)
        {
            try
            {
                // TODO: Get current user ID from authentication
                int currentUserId = 1; // Placeholder

                // Validate subscription
                var subscription = await _context.AgentSubscriptions
                    .Include(s => s.Agent)
                        .ThenInclude(a => a.Integrations.Where(i => i.IsActive))
                    .Include(s => s.Pricing)
                    .FirstOrDefaultAsync(s => s.Id == subscriptionId && 
                                            s.UserId == currentUserId && 
                                            s.Status == SubscriptionStatus.Active);

                if (subscription == null)
                {
                    return BadRequest(new { error = "Invalid or inactive subscription" });
                }

                var agent = subscription.Agent;

                // Check usage limits
                if (subscription.Pricing.UsageLimit.HasValue && 
                    subscription.CurrentUsage >= subscription.Pricing.UsageLimit.Value)
                {
                    return BadRequest(new { error = "Usage limit exceeded" });
                }

                // Get primary integration (highest priority)
                var integration = agent.Integrations
                    .Where(i => i.IsActive)
                    .OrderBy(i => i.Priority)
                    .FirstOrDefault();

                if (integration == null)
                {
                    return BadRequest(new { error = "No active integrations found for this agent" });
                }

                // Execute based on integration type
                AgentExecutionResult result;
                switch (integration.Type)
                {
                    case IntegrationType.N8n:
                        result = await _n8nService.ExecuteAgentAsync(agent, integration, inputData);
                        break;
                    
                    case IntegrationType.CustomAPI:
                        result = await ExecuteCustomApiIntegration(agent, integration, inputData);
                        break;
                    
                    case IntegrationType.Webhook:
                        result = await ExecuteWebhookIntegration(agent, integration, inputData);
                        break;
                    
                    case IntegrationType.Internal:
                        result = await ExecuteInternalServiceIntegration(agent, integration, inputData);
                        break;
                    
                    default:
                        return BadRequest(new { error = "Unsupported integration type" });
                }

                // Log usage
                var usageLog = new AgentUsageLog
                {
                    AgentSubscriptionId = subscriptionId,
                    AgentIntegrationId = integration.Id,
                    ExecutionTime = result.ExecutionTime,
                    Status = result.Success ? AgentExecutionStatus.Success : AgentExecutionStatus.Failed,
                    InputData = JsonSerializer.Serialize(inputData),
                    OutputData = result.Data,
                    ErrorMessage = result.ErrorMessage,
                    ExecutionDurationMs = result.ExecutionDurationMs,
                    Cost = result.Cost
                };

                _context.AgentUsageLogs.Add(usageLog);

                // Update subscription usage
                subscription.CurrentUsage++;
                await _context.SaveChangesAsync();

                return Ok(new 
                { 
                    success = result.Success,
                    data = result.Data,
                    error = result.ErrorMessage,
                    executionId = usageLog.Id,
                    duration = result.ExecutionDurationMs,
                    cost = result.Cost
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        /// <summary>
        /// Test agent integration without affecting usage limits
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> TestAgent(int agentId, [FromBody] object inputData)
        {
            try
            {
                var agent = await _context.Agents
                    .Include(a => a.Integrations.Where(i => i.IsActive))
                    .FirstOrDefaultAsync(a => a.Id == agentId && a.IsActive);

                if (agent == null)
                {
                    return NotFound(new { error = "Agent not found" });
                }

                var integration = agent.Integrations
                    .Where(i => i.IsActive)
                    .OrderBy(i => i.Priority)
                    .FirstOrDefault();

                if (integration == null)
                {
                    return BadRequest(new { error = "No active integrations found" });
                }

                // Execute test (only for N8n workflows for now)
                if (integration.Type == IntegrationType.N8n)
                {
                    var result = await _n8nService.ExecuteAgentAsync(agent, integration, inputData);
                    
                    return Ok(new 
                    { 
                        success = result.Success,
                        data = result.Data,
                        error = result.ErrorMessage,
                        duration = result.ExecutionDurationMs
                    });
                }

                return BadRequest(new { error = "Test execution not supported for this integration type" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // ===== INTEGRATION EXECUTION METHODS =====

        private async Task<AgentExecutionResult> ExecuteCustomApiIntegration(Agent agent, AgentIntegration integration, object inputData)
        {
            // Placeholder for custom API integration
            await Task.Delay(100);
            return new AgentExecutionResult
            {
                Success = true,
                Data = JsonSerializer.Serialize(new { message = "Custom API integration executed", input = inputData }),
                ExecutionDurationMs = 100
            };
        }

        private async Task<AgentExecutionResult> ExecuteWebhookIntegration(Agent agent, AgentIntegration integration, object inputData)
        {
            // Placeholder for webhook integration
            await Task.Delay(50);
            return new AgentExecutionResult
            {
                Success = true,
                Data = JsonSerializer.Serialize(new { message = "Webhook integration executed", input = inputData }),
                ExecutionDurationMs = 50
            };
        }

        private async Task<AgentExecutionResult> ExecuteInternalServiceIntegration(Agent agent, AgentIntegration integration, object inputData)
        {
            // Placeholder for internal service integration
            await Task.Delay(200);
            return new AgentExecutionResult
            {
                Success = true,
                Data = JsonSerializer.Serialize(new { message = "Internal service integration executed", input = inputData }),
                ExecutionDurationMs = 200
            };
        }

        // ===== HELPER METHODS =====

        private async Task<bool> AgentExists(int id)
        {
            return await _context.Agents.AnyAsync(e => e.Id == id);
        }
    }
}

