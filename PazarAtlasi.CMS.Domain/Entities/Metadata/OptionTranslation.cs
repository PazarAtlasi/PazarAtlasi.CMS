using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    public class OptionTranslation : Entity<int>
    {
        public int OptionId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }

        // Navigation Properties
        [ForeignKey("OptionId")]
        public virtual Option Option { get; set; } = null!;
        
        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; } = null!;
    }
}