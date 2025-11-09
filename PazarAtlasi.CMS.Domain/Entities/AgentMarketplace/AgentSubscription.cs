using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Entities.Identity;
using PazarAtlasi.CMS.Domain.Enums;

namespace PazarAtlasi.CMS.Domain.Entities.AgentMarketplace
{
    /// <summary>
    /// Customer subscriptions to agents
    /// </summary>
    public class AgentSubscription : Entity<int>
    {
        public int AgentId { get; set; }
        public int UserId { get; set; }
        public int AgentPricingId { get; set; }
        
        /// <summary>
        /// When the subscription started
        /// </summary>
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// When the subscription ends (null for active subscriptions)
        /// </summary>
        public DateTime? EndDate { get; set; }
        
        /// <summary>
        /// Current subscription status
        /// </summary>
        public SubscriptionStatus Status { get; set; }
        
        /// <summary>
        /// Number of agents (for per-agent pricing like call center)
        /// </summary>
        public int? AgentCount { get; set; }
        
        /// <summary>
        /// Current usage count in this billing cycle
        /// </summary>
        public int CurrentUsage { get; set; } = 0;
        
        /// <summary>
        /// When the usage counter was last reset
        /// </summary>
        public DateTime LastUsageReset { get; set; }
        
        /// <summary>
        /// Next billing date
        /// </summary>
        public DateTime? NextBillingDate { get; set; }
        
        /// <summary>
        /// Last amount billed
        /// </summary>
        public decimal? LastBilledAmount { get; set; }
        
        /// <summary>
        /// Total cost accumulated for this subscription
        /// </summary>
        public decimal TotalCost { get; set; } = 0;
        
        /// <summary>
        /// Additional configuration for this subscription
        /// </summary>
        public string? ConfigurationJson { get; set; }
        
        // Navigation Properties
        public virtual Agent Agent { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual AgentPricing Pricing { get; set; } = null!;
        public virtual ICollection<AgentUsageLog> UsageLogs { get; set; } = new List<AgentUsageLog>();
    }
}
