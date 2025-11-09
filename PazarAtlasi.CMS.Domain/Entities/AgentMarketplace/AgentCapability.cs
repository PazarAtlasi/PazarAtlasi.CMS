using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.AgentMarketplace
{
    /// <summary>
    /// Represents a capability/feature of an agent
    /// </summary>
    public class AgentCapability : Entity<int>
    {
        public int AgentId { get; set; }
        
        /// <summary>
        /// Capability name (default language)
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Capability description (default language)
        /// </summary>
        public string Description { get; set; } = string.Empty;
        
        /// <summary>
        /// Icon class for UI display
        /// </summary>
        public string IconClass { get; set; } = string.Empty;
        
        /// <summary>
        /// Display order
        /// </summary>
        public int SortOrder { get; set; } = 0;
        
        /// <summary>
        /// Whether this capability is highlighted as a key feature
        /// </summary>
        public bool IsKeyFeature { get; set; } = false;
        
        /// <summary>
        /// Whether this capability is active/enabled
        /// </summary>
        public bool IsActive { get; set; } = true;
        
        // Navigation Properties
        public virtual Agent Agent { get; set; } = null!;
        public virtual ICollection<AgentCapabilityTranslation> Translations { get; set; } = new List<AgentCapabilityTranslation>();
    }
}
