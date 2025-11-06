using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    public class Trademark : Entity<int>
    {
        public int? ParentId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string IntegrationCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;

        // Navigation Properties
        [ForeignKey("ParentId")]
        public virtual Trademark? ParentTrademark { get; set; }
        
        public virtual ICollection<Trademark> ChildTrademarks { get; set; } = new List<Trademark>();
        public virtual ICollection<TrademarkTranslation> Translations { get; set; } = new List<TrademarkTranslation>();
        public virtual ICollection<TrademarkProduct> TrademarkProducts { get; set; } = new List<TrademarkProduct>();
    }
}