using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Enums;

namespace PazarAtlasi.CMS.Domain.Entities.AgentMarketplace
{
    /// <summary>
    /// Logs agent usage for billing and monitoring purposes
    /// </summary>
    public class AgentUsageLog : Entity<int>
    {
        public int AgentSubscriptionId { get; set; }
        
        /// <summary>
        /// When the agent was executed
        /// </summary>
        public DateTime ExecutionTime { get; set; }
        
        /// <summary>
        /// Execution status
        /// </summary>
        public AgentExecutionStatus Status { get; set; }
        
        /// <summary>
        /// Input data sent to the agent (JSON)
        /// </summary>
        public string? InputData { get; set; }
        
        /// <summary>
        /// Output data from the agent (JSON)
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
        public decimal? Cost { get; set; }
        
        /// <summary>
        /// Integration that was used for this execution
        /// </summary>
        public int? AgentIntegrationId { get; set; }
        
        // Navigation Properties
        public virtual AgentSubscription Subscription { get; set; } = null!;
        public virtual AgentIntegration? Integration { get; set; }
    }
}
