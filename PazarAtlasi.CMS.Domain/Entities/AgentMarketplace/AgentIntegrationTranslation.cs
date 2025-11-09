using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PazarAtlasi.CMS.Domain.Entities.AgentMarketplace
{
    public class AgentIntegrationTranslation : Entity<int>
    {
        public int AgentIntegrationId { get; set; }
        public int LanguageId { get; set; }
        
        /// <summary>
        /// Translated integration name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Translated integration description
        /// </summary>
        public string? Description { get; set; }

        // Navigation Properties
        [ForeignKey("AgentIntegrationId")]
        public virtual AgentIntegration AgentIntegration { get; set; } = null!;
        
        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; } = null!;
    }
}
