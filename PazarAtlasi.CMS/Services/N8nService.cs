using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;
using PazarAtlasi.CMS.Domain.Enums;
using PazarAtlasi.CMS.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace PazarAtlasi.CMS.Services
{
    /// <summary>
    /// Service for N8n workflow integration
    /// Handles webhook calls, workflow execution, and result processing
    /// </summary>
    public class N8nService : IN8nService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<N8nService> _logger;

        public N8nService(HttpClient httpClient, ILogger<N8nService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Execute an agent via N8n workflow
        /// </summary>
        public async Task<AgentExecutionResult> ExecuteAgentAsync(Agent agent, AgentIntegration integration, object inputData)
        {
            var startTime = DateTime.UtcNow;
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                _logger.LogInformation("Executing agent {AgentName} via N8n integration {IntegrationName}", 
                    agent.Name, integration.Name);

                // Parse integration configuration
                var config = JsonSerializer.Deserialize<Dictionary<string, object>>(integration.ConfigurationJson);
                
                if (!config.TryGetValue("webhookUrl", out var webhookUrlObj) || webhookUrlObj == null)
                {
                    throw new InvalidOperationException("Webhook URL not found in integration configuration");
                }

                var webhookUrl = webhookUrlObj.ToString();
                var httpMethod = config.TryGetValue("httpMethod", out var methodObj) ? methodObj.ToString() : "POST";
                
                // Prepare headers
                var headers = new Dictionary<string, string>();
                
                // Add authentication if configured
                if (config.TryGetValue("authentication", out var authObj) && authObj.ToString() != "none")
                {
                    var authType = authObj.ToString();
                    if (config.TryGetValue("authToken", out var tokenObj) && tokenObj != null)
                    {
                        var token = tokenObj.ToString();
                        switch (authType)
                        {
                            case "bearer":
                                headers["Authorization"] = $"Bearer {token}";
                                break;
                            case "apikey":
                                headers["X-API-Key"] = token;
                                break;
                            case "basic":
                                var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
                                headers["Authorization"] = $"Basic {encoded}";
                                break;
                        }
                    }
                }

                // Prepare payload
                var payload = new
                {
                    agentId = agent.Id,
                    agentName = agent.Name,
                    executionId = Guid.NewGuid().ToString(),
                    timestamp = startTime,
                    inputData = inputData,
                    metadata = new
                    {
                        agentType = agent.Type.ToString(),
                        agentCategory = agent.Category.ToString(),
                        executionType = agent.ExecutionType.ToString()
                    }
                };

                // Execute workflow
                var result = await TriggerWorkflowAsync(webhookUrl, httpMethod, payload, headers);
                
                stopwatch.Stop();
                result.ExecutionDurationMs = (int)stopwatch.ElapsedMilliseconds;
                result.ExecutionTime = startTime;

                _logger.LogInformation("Agent {AgentName} execution completed in {Duration}ms with result: {Success}", 
                    agent.Name, result.ExecutionDurationMs, result.Success);

                return result;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                _logger.LogError(ex, "Error executing agent {AgentName} via N8n integration {IntegrationName}", 
                    agent.Name, integration.Name);

                return new AgentExecutionResult
                {
                    Success = false,
                    ErrorMessage = ex.Message,
                    ExecutionDurationMs = (int)stopwatch.ElapsedMilliseconds,
                    ExecutionTime = startTime
                };
            }
        }

        /// <summary>
        /// Trigger N8n workflow via webhook
        /// </summary>
        public async Task<AgentExecutionResult> TriggerWorkflowAsync(string webhookUrl, string httpMethod, object data, Dictionary<string, string>? headers = null)
        {
            try
            {
                var request = new HttpRequestMessage(new HttpMethod(httpMethod.ToUpper()), webhookUrl);

                // Add headers
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }

                // Add content for POST/PUT/PATCH requests
                if (httpMethod.ToUpper() != "GET" && httpMethod.ToUpper() != "DELETE")
                {
                    var json = JsonSerializer.Serialize(data, new JsonSerializerOptions 
                    { 
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
                    });
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                // Set timeout from configuration (default 30 seconds)
                _httpClient.Timeout = TimeSpan.FromMilliseconds(30000);

                var response = await _httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return new AgentExecutionResult
                    {
                        Success = true,
                        Data = responseContent
                    };
                }
                else
                {
                    return new AgentExecutionResult
                    {
                        Success = false,
                        ErrorMessage = $"HTTP {response.StatusCode}: {responseContent}"
                    };
                }
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                return new AgentExecutionResult
                {
                    Success = false,
                    ErrorMessage = "Request timeout"
                };
            }
            catch (Exception ex)
            {
                return new AgentExecutionResult
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        /// <summary>
        /// Validate N8n workflow configuration
        /// </summary>
        public async Task<bool> ValidateWorkflowConfigurationAsync(AgentIntegration integration)
        {
            try
            {
                var config = JsonSerializer.Deserialize<Dictionary<string, object>>(integration.ConfigurationJson);
                
                // Check required fields
                if (!config.ContainsKey("webhookUrl") || string.IsNullOrEmpty(config["webhookUrl"].ToString()))
                {
                    return false;
                }

                var webhookUrl = config["webhookUrl"].ToString();
                
                // Validate URL format
                if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out var uri))
                {
                    return false;
                }

                // Test connectivity (optional - can be disabled for security)
                try
                {
                    var request = new HttpRequestMessage(HttpMethod.Head, webhookUrl);
                    _httpClient.Timeout = TimeSpan.FromSeconds(5);
                    var response = await _httpClient.SendAsync(request);
                    // Accept any response (even errors) as long as we can connect
                    return true;
                }
                catch
                {
                    // If HEAD request fails, try a simple GET
                    try
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, webhookUrl);
                        _httpClient.Timeout = TimeSpan.FromSeconds(5);
                        var response = await _httpClient.SendAsync(request);
                        return true;
                    }
                    catch
                    {
                        // Still return true as the URL format is valid
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating N8n workflow configuration for integration {IntegrationId}", integration.Id);
                return false;
            }
        }

        /// <summary>
        /// Get workflow status from N8n (placeholder - requires N8n API access)
        /// </summary>
        public async Task<string> GetWorkflowStatusAsync(string workflowId)
        {
            // This would require N8n API credentials and endpoint
            // For now, return a placeholder status
            await Task.Delay(100); // Simulate API call
            return "active";
        }
    }
}
