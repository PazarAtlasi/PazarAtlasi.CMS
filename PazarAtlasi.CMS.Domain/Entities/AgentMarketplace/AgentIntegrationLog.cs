using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Enums;

namespace PazarAtlasi.CMS.Domain.Entities.AgentMarketplace
{
    /// <summary>
    /// Logs for agent integration executions
    /// </summary>
    public class AgentIntegrationLog : Entity<int>
    {
        public int AgentIntegrationId { get; set; }
        public int? AgentSubscriptionId { get; set; }
        
        public DateTime ExecutionTime { get; set; }
        public IntegrationExecutionStatus Status { get; set; }
        
        /// <summary>
        /// Input data sent to the integration
        /// </summary>
        public string? InputData { get; set; }
        
        /// <summary>
        /// Response/output from the integration
        /// </summary>
        public string? OutputData { get; set; }
        
        /// <summary>
        /// Error message if execution failed
        /// </summary>
        public string? ErrorMessage { get; set; }
        
        /// <summary>
        /// Execution duration in milliseconds
        /// </summary>
        public int ExecutionDurationMs { get; set; }
        
        /// <summary>
        /// Cost of this execution (if applicable)
        /// </summary>
        public decimal? ExecutionCost { get; set; }
        
        // Navigation Properties
        public virtual AgentIntegration Integration { get; set; } = null!;
        public virtual AgentSubscription? Subscription { get; set; }
    }
}
