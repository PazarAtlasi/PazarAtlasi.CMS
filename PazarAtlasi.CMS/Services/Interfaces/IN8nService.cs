using PazarAtlasi.CMS.Domain.Entities.AgentMarketplace;

namespace PazarAtlasi.CMS.Services.Interfaces
{
    /// <summary>
    /// Service for N8n workflow integration
    /// </summary>
    public interface IN8nService
    {
        /// <summary>
        /// Execute an agent via N8n workflow
        /// </summary>
        Task<AgentExecutionResult> ExecuteAgentAsync(Agent agent, AgentIntegration integration, object inputData);

        /// <summary>
        /// Trigger N8n workflow via webhook
        /// </summary>
        Task<AgentExecutionResult> TriggerWorkflowAsync(string webhookUrl, string httpMethod, object data, Dictionary<string, string>? headers = null);

        /// <summary>
        /// Validate N8n workflow configuration
        /// </summary>
        Task<bool> ValidateWorkflowConfigurationAsync(AgentIntegration integration);

        /// <summary>
        /// Get workflow status from N8n
        /// </summary>
        Task<string> GetWorkflowStatusAsync(string workflowId);
    }

    /// <summary>
    /// Result of agent execution
    /// </summary>
    public class AgentExecutionResult
    {
        public bool Success { get; set; }
        public string? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public int ExecutionDurationMs { get; set; }
        public decimal? Cost { get; set; }
        public DateTime ExecutionTime { get; set; } = DateTime.UtcNow;
    }
}
