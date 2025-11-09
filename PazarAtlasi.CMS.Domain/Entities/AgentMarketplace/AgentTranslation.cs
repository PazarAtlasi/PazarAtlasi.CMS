using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PazarAtlasi.CMS.Domain.Entities.AgentMarketplace
{
    public class AgentTranslation : Entity<int>
    {
        public int AgentId { get; set; }
        public int LanguageId { get; set; }
        
        /// <summary>
        /// Translated name of the agent
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Translated short description for listings
        /// </summary>
        public string Description { get; set; } = string.Empty;
        
        /// <summary>
        /// Translated detailed description for detail page
        /// </summary>
        public string DetailedDescription { get; set; } = string.Empty;

        // Navigation Properties
        [ForeignKey("AgentId")]
        public virtual Agent Agent { get; set; } = null!;
        
        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; } = null!;
    }
}
