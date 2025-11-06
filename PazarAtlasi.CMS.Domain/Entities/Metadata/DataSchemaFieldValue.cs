using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    /// <summary>
    /// Stores the actual values for product data schema fields
    /// Similar to SectionItemFieldValue in Content system
    /// </summary>
    public class DataSchemaFieldValue : Entity<int>
    {
        /// <summary>
        /// Reference to the product this value belongs to
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Reference to the data schema
        /// </summary>
        public int SchemaId { get; set; }

        /// <summary>
        /// Reference to the field definition
        /// </summary>
        public int FieldId { get; set; }

        /// <summary>
        /// The actual value for this field (for non-translatable fields)
        /// For translatable fields, this can be the default language value
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// JSON data for complex field types (arrays, objects, etc.)
        /// Format: {"color": "#FF0000", "size": "large"} or ["option1", "option2"]
        /// </summary>
        public string? JsonValue { get; set; }

        /// <summary>
        /// Numeric value for calculations and sorting (optional)
        /// </summary>
        public decimal? NumericValue { get; set; }

        /// <summary>
        /// Boolean value for yes/no fields (optional)
        /// </summary>
        public bool? BooleanValue { get; set; }

        /// <summary>
        /// Date value for date fields (optional)
        /// </summary>
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// Display order for this value (useful for multi-value fields)
        /// </summary>
        public int SortOrder { get; set; } = 0;

        // Navigation Properties
        /// <summary>
        /// Product this value belongs to
        /// </summary>
        public virtual Product Product { get; set; } = null!;

        /// <summary>
        /// Data schema this value belongs to
        /// </summary>
        public virtual DataSchema DataSchema { get; set; } = null!;

        /// <summary>
        /// Field definition this value is based on
        /// </summary>
        public virtual DataSchemaField DataSchemaField { get; set; } = null!;

        /// <summary>
        /// Translations for this field value (for translatable fields)
        /// </summary>
        public virtual ICollection<DataSchemaFieldValueTranslation> Translations { get; set; } = new List<DataSchemaFieldValueTranslation>();
    }
}