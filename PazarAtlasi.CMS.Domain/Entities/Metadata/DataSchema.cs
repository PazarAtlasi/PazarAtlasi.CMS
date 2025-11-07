using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    /// <summary>
    /// Represents a data schema template for product specifications
    /// Similar to Section in Content system
    /// </summary>
    public class DataSchema : Entity<int>
    {
        /// <summary>
        /// Schema name (e.g., "iPhone 15 Specifications", "Laptop Specifications")
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Unique key for this schema (e.g., "iphone-15-specs", "laptop-specs")
        /// </summary>
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// Schema description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// JSON configuration for schema settings
        /// </summary>
        public string? Configuration { get; set; }

        /// <summary>
        /// Display order for this schema
        /// </summary>
        public int SortOrder { get; set; } = 0;

        /// <summary>
        /// Whether this schema is active and can be used
        /// </summary>
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        /// <summary>
        /// Fields defined in this schema
        /// </summary>
        public virtual ICollection<DataSchemaField> Fields { get; set; } = new List<DataSchemaField>();

        /// <summary>
        /// Products using this schema
        /// </summary>
        public virtual ICollection<ProductDataSchema> ProductDataSchemas { get; set; } = new List<ProductDataSchema>();

        /// <summary>
        /// Field values for products using this schema
        /// </summary>
        public virtual ICollection<DataSchemaFieldValue> FieldValues { get; set; } = new List<DataSchemaFieldValue>();

        /// <summary>
        /// Translations for this schema
        /// </summary>
        public virtual ICollection<DataSchemaTranslation> Translations { get; set; } = new List<DataSchemaTranslation>();
    }
}