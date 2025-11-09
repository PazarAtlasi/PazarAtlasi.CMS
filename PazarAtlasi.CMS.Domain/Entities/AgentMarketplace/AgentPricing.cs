using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Enums;

namespace PazarAtlasi.CMS.Domain.Entities.AgentMarketplace
{
    /// <summary>
    /// Pricing model for agents (monthly, per-use, per-agent, etc.)
    /// </summary>
    public class AgentPricing : Entity<int>
    {
        public int AgentId { get; set; }
        
        /// <summary>
        /// Type of pricing (Monthly, PerUse, PerAgent, OneTime)
        /// </summary>
        public PricingType Type { get; set; }
        
        /// <summary>
        /// Price amount
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Currency code (USD, EUR, TRY, etc.)
        /// </summary>
        public string Currency { get; set; } = "USD";
        
        /// <summary>
        /// Usage limit per billing cycle (for monthly plans)
        /// </summary>
        public int? UsageLimit { get; set; }
        
        /// <summary>
        /// Pricing description (default language)
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Features included in this pricing plan
        /// </summary>
        public string? Features { get; set; }
        
        /// <summary>
        /// Whether this is the default/recommended pricing
        /// </summary>
        public bool IsDefault { get; set; } = false;
        
        /// <summary>
        /// Whether this pricing is currently active
        /// </summary>
        public bool IsActive { get; set; } = true;
        
        /// <summary>
        /// Display order for multiple pricing options
        /// </summary>
        public int SortOrder { get; set; } = 0;
        
        // Navigation Properties
        public virtual Agent Agent { get; set; } = null!;
        public virtual ICollection<AgentSubscription> Subscriptions { get; set; } = new List<AgentSubscription>();
        public virtual ICollection<AgentPricingTranslation> Translations { get; set; } = new List<AgentPricingTranslation>();
    }
}
