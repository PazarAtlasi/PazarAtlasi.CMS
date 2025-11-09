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
using PazarAtlasi.CMS.Models.ViewModels;

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
        public async Task<IActionResult> Index(AgentMarketplaceFilterViewModel filter, int page = 1, int pageSize = 12)
        {
            filter ??= new AgentMarketplaceFilterViewModel();
            
            var query = _context.Agents
                .Include(a => a.Pricings.Where(p => p.IsActive))
                .Include(a => a.Capabilities.Where(c => c.IsKeyFeature))
                .Where(a => a.IsActive);

            // Apply filters
            if (filter.Category.HasValue)
                query = query.Where(a => a.Category == filter.Category.Value);

            if (filter.Type.HasValue)
                query = query.Where(a => a.Type == filter.Type.Value);

            if (!string.IsNullOrEmpty(filter.SearchTerm))
                query = query.Where(a => a.Name.Contains(filter.SearchTerm) || a.Description.Contains(filter.SearchTerm));

            if (filter.IsFeatured.HasValue)
                query = query.Where(a => a.IsFeatured == filter.IsFeatured.Value);

            // Apply sorting
            query = filter.SortBy?.ToLower() switch
            {
                "name" => filter.SortDirection == "desc" ? query.OrderByDescending(a => a.Name) : query.OrderBy(a => a.Name),
                "category" => filter.SortDirection == "desc" ? query.OrderByDescending(a => a.Category) : query.OrderBy(a => a.Category),
                "type" => filter.SortDirection == "desc" ? query.OrderByDescending(a => a.Type) : query.OrderBy(a => a.Type),
                _ => query.OrderByDescending(a => a.IsFeatured).ThenBy(a => a.SortOrder).ThenBy(a => a.Name)
            };

            var totalCount = await query.CountAsync();
            var agents = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var viewModel = new AgentMarketplaceIndexViewModel
            {
                Agents = agents.Select(MapToAgentCardViewModel).ToList(),
                Categories = Enum.GetValues<AgentCategory>().Select(c => new AgentCategoryViewModel 
                { 
                    Value = c, 
                    DisplayName = c.ToString() 
                }).ToList(),
                Types = Enum.GetValues<AgentType>().Select(t => new AgentTypeViewModel 
                { 
                    Value = t, 
                    DisplayName = t.ToString() 
                }).ToList(),
                Filter = filter,
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = page
            };

            return View(viewModel);
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

            // TODO: Get current user ID from authentication
            int currentUserId = 1; // Placeholder

            // Check if user has active subscription
            var userSubscription = await _context.AgentSubscriptions
                .Include(s => s.Pricing)
                .FirstOrDefaultAsync(s => s.AgentId == id && 
                                        s.UserId == currentUserId && 
                                        s.Status == SubscriptionStatus.Active);

            var viewModel = MapToAgentDetailsViewModel(agent);
            viewModel.UserSubscription = userSubscription != null ? MapToAgentSubscriptionViewModel(userSubscription) : null;
            viewModel.CanTest = true; // For now, allow all users to test

            return View(viewModel);
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

            var viewModel = new MySubscriptionsViewModel
            {
                ActiveSubscriptions = subscriptions
                    .Where(s => s.Status == SubscriptionStatus.Active)
                    .Select(MapToAgentSubscriptionViewModel)
                    .ToList(),
                ExpiredSubscriptions = subscriptions
                    .Where(s => s.Status != SubscriptionStatus.Active)
                    .Select(MapToAgentSubscriptionViewModel)
                    .ToList(),
                TotalMonthlyCost = subscriptions
                    .Where(s => s.Status == SubscriptionStatus.Active && s.Pricing.Type == PricingType.Monthly)
                    .Sum(s => s.Pricing.Price),
                TotalUsageThisMonth = subscriptions
                    .Where(s => s.Status == SubscriptionStatus.Active)
                    .Sum(s => s.CurrentUsage)
            };

            return View(viewModel);
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
            var viewModel = new AgentCreateEditViewModel
            {
                AvailableAgentTypes = Enum.GetValues<AgentType>().Select(t => new AgentTypeViewModel 
                { 
                    Value = t, 
                    DisplayName = t.ToString() 
                }).ToList(),
                AvailableAgentCategories = Enum.GetValues<AgentCategory>().Select(c => new AgentCategoryViewModel 
                { 
                    Value = c, 
                    DisplayName = c.ToString() 
                }).ToList(),
                AvailableExecutionTypes = Enum.GetValues<AgentExecutionType>().Select(e => new AgentExecutionTypeViewModel 
                { 
                    Value = e, 
                    DisplayName = e.ToString() 
                }).ToList(),
                AvailableIntegrationTypes = Enum.GetValues<IntegrationType>().Select(i => new IntegrationTypeViewModel 
                { 
                    Value = i, 
                    DisplayName = GetIntegrationTypeDisplayName(i) 
                }).ToList(),
                AvailableIntegrationTriggers = Enum.GetValues<IntegrationTrigger>().Select(t => new IntegrationTriggerViewModel 
                { 
                    Value = t, 
                    DisplayName = t.ToString() 
                }).ToList()
            };
            
            return View(viewModel);
        }

        /// <summary>
        /// Admin: Create new agent (POST)
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgentCreateEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var agent = MapToAgentEntity(viewModel);

                // Process integrations
                if (viewModel.Integrations != null && viewModel.Integrations.Any())
                {
                    int integrationIndex = 0;
                    foreach (var integrationViewModel in viewModel.Integrations.Where(i => !string.IsNullOrEmpty(i.Name)))
                    {
                        var integration = MapToAgentIntegrationEntity(integrationViewModel);
                        // Convert form data to JSON configuration
                        var configJson = ProcessIntegrationConfiguration(integration, integrationIndex);
                        integration.ConfigurationJson = configJson;
                        integration.Agent = agent;
                        agent.Integrations.Add(integration);
                        integrationIndex++;
                    }
                }

                // Process capabilities
                if (viewModel.Capabilities != null && viewModel.Capabilities.Any())
                {
                    foreach (var capabilityViewModel in viewModel.Capabilities.Where(c => !string.IsNullOrEmpty(c.Name)))
                    {
                        var capability = MapToAgentCapabilityEntity(capabilityViewModel);
                        capability.Agent = agent;
                        agent.Capabilities.Add(capability);
                    }
                }

                // Process pricings
                if (viewModel.Pricings != null && viewModel.Pricings.Any())
                {
                    foreach (var pricingViewModel in viewModel.Pricings)
                    {
                        var pricing = MapToAgentPricingEntity(pricingViewModel);
                        pricing.Agent = agent;
                        agent.Pricings.Add(pricing);
                    }
                }

                _context.Agents.Add(agent);
                await _context.SaveChangesAsync();

                TempData["Success"] = $"Agent '{agent.Name}' created successfully with {agent.Integrations.Count} integration(s)!";
                return RedirectToAction(nameof(Manage));
            }

            // Reload dropdown data
            viewModel.AvailableAgentTypes = Enum.GetValues<AgentType>().Select(t => new AgentTypeViewModel 
            { 
                Value = t, 
                DisplayName = t.ToString() 
            }).ToList();
            
            viewModel.AvailableAgentCategories = Enum.GetValues<AgentCategory>().Select(c => new AgentCategoryViewModel 
            { 
                Value = c, 
                DisplayName = c.ToString() 
            }).ToList();
            
            viewModel.AvailableExecutionTypes = Enum.GetValues<AgentExecutionType>().Select(e => new AgentExecutionTypeViewModel 
            { 
                Value = e, 
                DisplayName = e.ToString() 
            }).ToList();
            
            viewModel.AvailableIntegrationTypes = Enum.GetValues<IntegrationType>().Select(i => new IntegrationTypeViewModel 
            { 
                Value = i, 
                DisplayName = GetIntegrationTypeDisplayName(i) 
            }).ToList();
            
            viewModel.AvailableIntegrationTriggers = Enum.GetValues<IntegrationTrigger>().Select(t => new IntegrationTriggerViewModel 
            { 
                Value = t, 
                DisplayName = t.ToString() 
            }).ToList();
            
            return View(viewModel);
        }

        /// <summary>
        /// Process integration configuration from form data to JSON
        /// </summary>
        private string ProcessIntegrationConfiguration(AgentIntegration integration, int integrationIndex)
        {
            var config = new Dictionary<string, object>();

            // Get configuration from Request.Form based on integration index
            var formKeys = Request.Form.Keys.Where(k => k.Contains($"Integrations[{integrationIndex}].ConfigurationJson."));
            
            // Debug: Log all form keys for this integration
            var allKeys = Request.Form.Keys.ToList();
            System.Diagnostics.Debug.WriteLine($"All form keys: {string.Join(", ", allKeys)}");
            System.Diagnostics.Debug.WriteLine($"Looking for keys containing: Integrations[{integrationIndex}].ConfigurationJson.");
            System.Diagnostics.Debug.WriteLine($"Found keys: {string.Join(", ", formKeys)}");
            
            foreach (var key in formKeys)
            {
                var configKey = key.Split('.').Last();
                var value = Request.Form[key].ToString();
                
                System.Diagnostics.Debug.WriteLine($"Processing key: {key}, configKey: {configKey}, value: {value}");
                
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

            var json = JsonSerializer.Serialize(config, new JsonSerializerOptions 
            { 
                WriteIndented = true 
            });
            
            System.Diagnostics.Debug.WriteLine($"Generated JSON for integration {integrationIndex}: {json}");
            
            return json;
        }

        /// <summary>
        /// Admin: Edit agent (GET)
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

            var viewModel = new AgentCreateEditViewModel
            {
                Id = agent.Id,
                Name = agent.Name,
                Description = agent.Description,
                DetailedDescription = agent.DetailedDescription,
                Version = agent.Version,
                Type = agent.Type,
                Category = agent.Category,
                ExecutionType = agent.ExecutionType,
                IconClass = agent.IconClass,
                ImageUrl = agent.ImageUrl,
                SortOrder = agent.SortOrder,
                IsActive = agent.IsActive,
                IsFeatured = agent.IsFeatured,
                IsPublic = agent.IsPublic,
                
                // Map capabilities
                Capabilities = agent.Capabilities.Select(c => new AgentCapabilityCreateEditViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive
                }).ToList(),
                
                // Map pricings
                Pricings = agent.Pricings.Select(p => new AgentPricingCreateEditViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.Type,
                    Price = p.Price,
                    Currency = p.Currency,
                    UsageLimit = p.UsageLimit,
                    Features = p.Features,
                    SortOrder = p.SortOrder
                }).ToList(),
                
                // Map integrations
                Integrations = agent.Integrations.Select(i => new AgentIntegrationCreateEditViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Type = i.Type,
                    TriggerType = i.TriggerType,
                    Priority = i.Priority,
                    IsActive = i.IsActive,
                    ConfigurationJson = i.ConfigurationJson
                }).ToList()
            };

            // Populate dropdown data
            viewModel.AvailableAgentTypes = Enum.GetValues<AgentType>().Select(t => new AgentTypeViewModel 
            { 
                Value = t, 
                DisplayName = t.ToString() 
            }).ToList();
            
            viewModel.AvailableAgentCategories = Enum.GetValues<AgentCategory>().Select(c => new AgentCategoryViewModel 
            { 
                Value = c, 
                DisplayName = c.ToString() 
            }).ToList();
            
            viewModel.AvailableExecutionTypes = Enum.GetValues<AgentExecutionType>().Select(e => new AgentExecutionTypeViewModel 
            { 
                Value = e, 
                DisplayName = e.ToString() 
            }).ToList();
            
            viewModel.AvailableIntegrationTypes = Enum.GetValues<IntegrationType>().Select(i => new IntegrationTypeViewModel 
            { 
                Value = i, 
                DisplayName = GetIntegrationTypeDisplayName(i) 
            }).ToList();
            
            viewModel.AvailableIntegrationTriggers = Enum.GetValues<IntegrationTrigger>().Select(t => new IntegrationTriggerViewModel 
            { 
                Value = t, 
                DisplayName = t.ToString() 
            }).ToList();

            return View(viewModel);
        }

        /// <summary>
        /// Admin: Edit agent (POST)
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AgentCreateEditViewModel viewModel)
        {
            if (id != viewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var existingAgent = await _context.Agents
                        .Include(a => a.Pricings)
                        .Include(a => a.Capabilities)
                        .Include(a => a.Integrations)
                        .FirstOrDefaultAsync(a => a.Id == id);

                    if (existingAgent == null)
                        return NotFound();

                    // Update basic properties
                    existingAgent.Name = viewModel.Name;
                    existingAgent.Description = viewModel.Description;
                    existingAgent.DetailedDescription = viewModel.DetailedDescription;
                    existingAgent.Version = viewModel.Version;
                    existingAgent.Type = viewModel.Type;
                    existingAgent.Category = viewModel.Category;
                    existingAgent.ExecutionType = viewModel.ExecutionType;
                    existingAgent.IconClass = viewModel.IconClass;
                    existingAgent.ImageUrl = viewModel.ImageUrl;
                    existingAgent.SortOrder = viewModel.SortOrder;
                    existingAgent.IsActive = viewModel.IsActive;
                    existingAgent.IsFeatured = viewModel.IsFeatured;
                    existingAgent.IsPublic = viewModel.IsPublic;
                    existingAgent.UpdatedAt = DateTime.UtcNow;

                    // Update capabilities
                    existingAgent.Capabilities.Clear();
                    if (viewModel.Capabilities != null && viewModel.Capabilities.Any())
                    {
                        foreach (var capabilityViewModel in viewModel.Capabilities.Where(c => !string.IsNullOrEmpty(c.Name)))
                        {
                            var capability = MapToAgentCapabilityEntity(capabilityViewModel);
                            capability.Agent = existingAgent;
                            existingAgent.Capabilities.Add(capability);
                        }
                    }

                    // Update pricings
                    existingAgent.Pricings.Clear();
                    if (viewModel.Pricings != null && viewModel.Pricings.Any())
                    {
                        foreach (var pricingViewModel in viewModel.Pricings)
                        {
                            var pricing = MapToAgentPricingEntity(pricingViewModel);
                            pricing.Agent = existingAgent;
                            existingAgent.Pricings.Add(pricing);
                        }
                    }

                    // Update integrations
                    existingAgent.Integrations.Clear();
                    if (viewModel.Integrations != null && viewModel.Integrations.Any())
                    {
                        int integrationIndex = 0;
                        foreach (var integrationViewModel in viewModel.Integrations.Where(i => !string.IsNullOrEmpty(i.Name)))
                        {
                            var integration = MapToAgentIntegrationEntity(integrationViewModel);
                            // Convert form data to JSON configuration
                            var configJson = ProcessIntegrationConfiguration(integration, integrationIndex);
                            integration.ConfigurationJson = configJson;
                            integration.Agent = existingAgent;
                            existingAgent.Integrations.Add(integration);
                            integrationIndex++;
                        }
                    }

                    await _context.SaveChangesAsync();
                    
                    TempData["Success"] = $"Agent '{existingAgent.Name}' updated successfully with {existingAgent.Integrations.Count} integration(s)!";
                    return RedirectToAction(nameof(Manage));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AgentExists(viewModel.Id))
                        return NotFound();
                    throw;
                }
            }

            // Reload dropdown data
            PopulateDropdownData(viewModel);
            return View(viewModel);
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
                    
                    var testResult = new TestAgentResultViewModel
                    {
                        Success = result.Success,
                        Data = result.Data,
                        ErrorMessage = result.ErrorMessage,
                        ExecutionDurationMs = result.ExecutionDurationMs,
                        ExecutionTime = result.ExecutionTime
                    };
                    
                    return Ok(testResult);
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

        // ===== MAPPING METHODS =====

        private AgentCardViewModel MapToAgentCardViewModel(Agent agent)
        {
            return new AgentCardViewModel
            {
                Id = agent.Id,
                Name = agent.Name,
                Description = agent.Description,
                IconClass = agent.IconClass,
                ImageUrl = agent.ImageUrl,
                Type = agent.Type,
                Category = agent.Category,
                IsFeatured = agent.IsFeatured,
                IsActive = agent.IsActive,
                TopCapabilities = agent.Capabilities
                    .Where(c => c.IsKeyFeature)
                    .OrderBy(c => c.SortOrder)
                    .Take(3)
                    .Select(MapToAgentCapabilityViewModel)
                    .ToList(),
                Pricings = agent.Pricings
                    .Where(p => p.IsActive)
                    .Select(MapToAgentPricingViewModel)
                    .ToList(),
                StartingPrice = agent.Pricings
                    .Where(p => p.IsActive)
                    .OrderBy(p => p.Price)
                    .FirstOrDefault()?.Price,
                StartingPriceCurrency = agent.Pricings
                    .Where(p => p.IsActive)
                    .OrderBy(p => p.Price)
                    .FirstOrDefault()?.Currency
            };
        }

        private AgentDetailsViewModel MapToAgentDetailsViewModel(Agent agent)
        {
            return new AgentDetailsViewModel
            {
                Id = agent.Id,
                Name = agent.Name,
                Description = agent.Description,
                DetailedDescription = agent.DetailedDescription,
                IconClass = agent.IconClass,
                ImageUrl = agent.ImageUrl,
                Type = agent.Type,
                Category = agent.Category,
                ExecutionType = agent.ExecutionType,
                IsActive = agent.IsActive,
                IsFeatured = agent.IsFeatured,
                Version = agent.Version,
                Capabilities = agent.Capabilities
                    .OrderBy(c => c.SortOrder)
                    .Select(MapToAgentCapabilityViewModel)
                    .ToList(),
                Pricings = agent.Pricings
                    .Where(p => p.IsActive)
                    .Select(MapToAgentPricingViewModel)
                    .ToList(),
                Integrations = agent.Integrations
                    .Where(i => i.IsActive)
                    .Select(MapToAgentIntegrationViewModel)
                    .ToList()
            };
        }

        private AgentCapabilityViewModel MapToAgentCapabilityViewModel(AgentCapability capability)
        {
            return new AgentCapabilityViewModel
            {
                Id = capability.Id,
                Name = capability.Name,
                Description = capability.Description,
                IconClass = capability.IconClass,
                IsKeyFeature = capability.IsKeyFeature,
                SortOrder = capability.SortOrder
            };
        }

        private AgentPricingViewModel MapToAgentPricingViewModel(AgentPricing pricing)
        {
            return new AgentPricingViewModel
            {
                Id = pricing.Id,
                Type = pricing.Type,
                Price = pricing.Price,
                Currency = pricing.Currency,
                UsageLimit = pricing.UsageLimit,
                IsDefault = pricing.IsDefault,
                Description = pricing.Description ?? string.Empty,
                Features = pricing.Features ?? string.Empty,
                SortOrder = pricing.SortOrder
            };
        }

        private AgentIntegrationViewModel MapToAgentIntegrationViewModel(AgentIntegration integration)
        {
            return new AgentIntegrationViewModel
            {
                Id = integration.Id,
                Type = integration.Type,
                Name = integration.Name,
                ConfigurationJson = integration.ConfigurationJson,
                TriggerType = integration.TriggerType,
                Priority = integration.Priority,
                IsActive = integration.IsActive,
                Metadata = integration.Metadata
            };
        }

        private AgentSubscriptionViewModel MapToAgentSubscriptionViewModel(AgentSubscription subscription)
        {
            return new AgentSubscriptionViewModel
            {
                Id = subscription.Id,
                AgentId = subscription.AgentId,
                AgentName = subscription.Agent?.Name ?? "Unknown",
                UserId = subscription.UserId.ToString(),
                Pricing = MapToAgentPricingViewModel(subscription.Pricing),
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
                Status = subscription.Status,
                CurrentUsage = subscription.CurrentUsage,
                UsageLimit = subscription.Pricing?.UsageLimit,
                AgentCount = subscription.AgentCount ?? 1,
                TotalCost = subscription.TotalCost,
                NextBillingDate = subscription.NextBillingDate
            };
        }

        private Agent MapToAgentEntity(AgentCreateEditViewModel viewModel)
        {
            return new Agent
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                DetailedDescription = viewModel.DetailedDescription,
                Type = viewModel.Type,
                Category = viewModel.Category,
                ExecutionType = viewModel.ExecutionType,
                IconClass = viewModel.IconClass,
                ImageUrl = viewModel.ImageUrl,
                IsActive = viewModel.IsActive,
                IsFeatured = viewModel.IsFeatured,
                SortOrder = viewModel.SortOrder,
                Version = viewModel.Version
            };
        }

        private AgentCapability MapToAgentCapabilityEntity(AgentCapabilityCreateEditViewModel viewModel)
        {
            return new AgentCapability
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                IconClass = viewModel.IconClass,
                IsKeyFeature = viewModel.IsKeyFeature,
                SortOrder = viewModel.SortOrder,
                IsActive = viewModel.IsActive
            };
        }

        private AgentPricing MapToAgentPricingEntity(AgentPricingCreateEditViewModel viewModel)
        {
            return new AgentPricing
            {
                Id = viewModel.Id,
                Type = viewModel.Type,
                Price = viewModel.Price,
                Currency = viewModel.Currency,
                UsageLimit = viewModel.UsageLimit,
                IsDefault = viewModel.IsDefault,
                IsActive = viewModel.IsActive,
                Description = viewModel.Description,
                Features = viewModel.Features
            };
        }

        private AgentIntegration MapToAgentIntegrationEntity(AgentIntegrationCreateEditViewModel viewModel)
        {
            return new AgentIntegration
            {
                Id = viewModel.Id,
                Type = viewModel.Type,
                Name = viewModel.Name,
                ConfigurationJson = viewModel.ConfigurationJson,
                TriggerType = viewModel.TriggerType,
                Priority = viewModel.Priority,
                IsActive = viewModel.IsActive,
                Metadata = viewModel.Metadata
            };
        }

        private void PopulateDropdownData(AgentCreateEditViewModel viewModel)
        {
            viewModel.AvailableAgentTypes = Enum.GetValues<AgentType>().Select(t => new AgentTypeViewModel 
            { 
                Value = t, 
                DisplayName = t.ToString() 
            }).ToList();
            
            viewModel.AvailableAgentCategories = Enum.GetValues<AgentCategory>().Select(c => new AgentCategoryViewModel 
            { 
                Value = c, 
                DisplayName = c.ToString() 
            }).ToList();
            
            viewModel.AvailableExecutionTypes = Enum.GetValues<AgentExecutionType>().Select(e => new AgentExecutionTypeViewModel 
            { 
                Value = e, 
                DisplayName = e.ToString() 
            }).ToList();
            
            viewModel.AvailableIntegrationTypes = Enum.GetValues<IntegrationType>().Select(i => new IntegrationTypeViewModel 
            { 
                Value = i, 
                DisplayName = GetIntegrationTypeDisplayName(i) 
            }).ToList();
            
            viewModel.AvailableIntegrationTriggers = Enum.GetValues<IntegrationTrigger>().Select(t => new IntegrationTriggerViewModel 
            { 
                Value = t, 
                DisplayName = t.ToString() 
            }).ToList();
        }


        private string GetIntegrationTypeDisplayName(IntegrationType type)
        {
            return type switch
            {
                IntegrationType.N8n => "N8n Workflow",
                IntegrationType.CustomAPI => "Custom API",
                IntegrationType.Webhook => "Webhook",
                IntegrationType.Internal => "Internal Service",
                _ => type.ToString()
            };
        }
    }
}

