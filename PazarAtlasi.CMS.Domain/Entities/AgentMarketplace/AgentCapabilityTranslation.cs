using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PazarAtlasi.CMS.Domain.Entities.AgentMarketplace
{
    public class AgentCapabilityTranslation : Entity<int>
    {
        public int AgentCapabilityId { get; set; }
        public int LanguageId { get; set; }
        
        /// <summary>
        /// Translated capability name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Translated capability description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        // Navigation Properties
        [ForeignKey("AgentCapabilityId")]
        public virtual AgentCapability AgentCapability { get; set; } = null!;
        
        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; } = null!;
    }
}
