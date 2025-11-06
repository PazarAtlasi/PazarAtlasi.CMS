using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    /// <summary>
    /// Junction table linking products to data schemas
    /// Similar to SectionItemValue in Content system
    /// </summary>
    public class ProductDataSchema : Entity<int>
    {
        /// <summary>
        /// Reference to the product
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Reference to the data schema
        /// </summary>
        public int SchemaId { get; set; }

        /// <summary>
        /// Whether this schema is the primary schema for the product
        /// A product can have multiple schemas, but only one primary
        /// </summary>
        public bool IsPrimary { get; set; } = false;

        /// <summary>
        /// Display order when product has multiple schemas
        /// </summary>
        public int SortOrder { get; set; } = 0;

        /// <summary>
        /// Additional configuration for this product-schema relationship
        /// JSON format for custom settings
        /// </summary>
        public string? Configuration { get; set; }

        /// <summary>
        /// Whether this schema assignment is active
        /// </summary>
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        /// <summary>
        /// Product this schema is assigned to
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Data schema assigned to the product
        /// </summary>
        public virtual DataSchema DataSchema { get; set; } = null!;
    }
}