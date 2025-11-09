using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PazarAtlasi.CMS.Domain.Entities.AgentMarketplace
{
    public class AgentPricingTranslation : Entity<int>
    {
        public int AgentPricingId { get; set; }
        public int LanguageId { get; set; }
        
        /// <summary>
        /// Translated pricing description (e.g., "Per month", "Per usage", "Per agent")
        /// </summary>
        public string Description { get; set; } = string.Empty;
        
        /// <summary>
        /// Translated pricing details/features included
        /// </summary>
        public string? Features { get; set; }

        // Navigation Properties
        [ForeignKey("AgentPricingId")]
        public virtual AgentPricing AgentPricing { get; set; } = null!;
        
        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; } = null!;
    }
}
