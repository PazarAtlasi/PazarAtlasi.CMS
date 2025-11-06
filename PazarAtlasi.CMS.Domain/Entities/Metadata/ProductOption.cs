using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    /// <summary>
    /// Junction table between Product and Option with additional properties
    /// </summary>
    public class ProductOption : Entity<int>
    {
        public int ProductId { get; set; }
        public int OptionId { get; set; }
        public string? Value { get; set; }
        public string? JsonValue { get; set; }
        public decimal? PriceModifier { get; set; } = 0m;
        public int? StockQuantity { get; set; }
        public bool IsRequired { get; set; } = false;
        public bool IsDefault { get; set; } = false;
        public int SortOrder { get; set; } = 0;

        // Navigation Properties
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;
        
        [ForeignKey("OptionId")]
        public virtual Option Option { get; set; } = null!;
    }
}