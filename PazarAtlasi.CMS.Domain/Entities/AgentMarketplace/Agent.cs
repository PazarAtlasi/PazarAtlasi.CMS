using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Enums;

namespace PazarAtlasi.CMS.Domain.Entities.AgentMarketplace
{
    /// <summary>
    /// Represents an AI agent available in the marketplace
    /// </summary>
    public class Agent : Entity<int>
    {
        /// <summary>
        /// Agent name (default language)
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Short description for listings (default language)
        /// </summary>
        public string Description { get; set; } = string.Empty;
        
        /// <summary>
        /// Detailed description for detail page (default language)
        /// </summary>
        public string DetailedDescription { get; set; } = string.Empty;
        
        /// <summary>
        /// Type of agent (Reporting, CallCenter, etc.)
        /// </summary>
        public AgentType Type { get; set; }
        
        /// <summary>
        /// Category of agent (Business, Technical, etc.)
        /// </summary>
        public AgentCategory Category { get; set; }
        
        /// <summary>
        /// Icon class for UI display (e.g., "fas fa-robot")
        /// </summary>
        public string IconClass { get; set; } = string.Empty;
        
        /// <summary>
        /// Agent image URL for marketplace display
        /// </summary>
        public string? ImageUrl { get; set; }
        
        /// <summary>
        /// Whether this agent is active and available for purchase
        /// </summary>
        public bool IsActive { get; set; } = true;
        
        /// <summary>
        /// How this agent executes (Background, OnDemand, Scheduled)
        /// </summary>
        public AgentExecutionType ExecutionType { get; set; }
        
        /// <summary>
        /// Display order in marketplace
        /// </summary>
        public int SortOrder { get; set; } = 0;
        
        /// <summary>
        /// Whether this agent is featured in marketplace
        /// </summary>
        public bool IsFeatured { get; set; } = false;
        
        /// <summary>
        /// Agent version for updates and compatibility
        /// </summary>
        public string Version { get; set; } = "1.0.0";
        
        // Navigation Properties
        public virtual ICollection<AgentPricing> Pricings { get; set; } = new List<AgentPricing>();
        public virtual ICollection<AgentCapability> Capabilities { get; set; } = new List<AgentCapability>();
        public virtual ICollection<AgentSubscription> Subscriptions { get; set; } = new List<AgentSubscription>();
        public virtual ICollection<AgentIntegration> Integrations { get; set; } = new List<AgentIntegration>();
        public virtual ICollection<AgentTranslation> Translations { get; set; } = new List<AgentTranslation>();
    }
}
