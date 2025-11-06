using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    public class Variant : Entity<int>
    {
        public int ProductId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string IntegrationCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;

        // Navigation Properties
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;
        
        public virtual ICollection<VariantTranslation> Translations { get; set; } = new List<VariantTranslation>();
    }
}