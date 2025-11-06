using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    public class Product : Entity<int>
    {
        public int? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string IntegrationCode { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public ProductType Type { get; set; } = ProductType.Simple;
        public decimal TaxRate { get; set; } = 0;

        // Navigation Properties
        [ForeignKey("ParentId")]
        public virtual Product? ParentProduct { get; set; }
        
        public virtual ICollection<Product> ChildProducts { get; set; } = new List<Product>();
        public virtual ICollection<ProductTranslation> Translations { get; set; } = new List<ProductTranslation>();
        public virtual ICollection<Variant> Variants { get; set; } = new List<Variant>();
        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
        public virtual ICollection<TrademarkProduct> TrademarkProducts { get; set; } = new List<TrademarkProduct>();
        public virtual ICollection<ProductOption> ProductOptions { get; set; } = new List<ProductOption>();
        
        // Data Schema Navigation Properties
        public virtual ICollection<ProductDataSchema> ProductDataSchemas { get; set; } = new List<ProductDataSchema>();
        public virtual ICollection<DataSchemaFieldValue> DataSchemaFieldValues { get; set; } = new List<DataSchemaFieldValue>();
    }
}