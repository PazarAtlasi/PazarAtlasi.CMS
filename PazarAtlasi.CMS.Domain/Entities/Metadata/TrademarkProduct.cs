using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    public class TrademarkProduct : Entity<int>
    {
        public int TrademarkId { get; set; }
        public int ProductId { get; set; }

        // Navigation Properties
        [ForeignKey("TrademarkId")]
        public virtual Trademark Trademark { get; set; } = null!;
        
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;
    }
}