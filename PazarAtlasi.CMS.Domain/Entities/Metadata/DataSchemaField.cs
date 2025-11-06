using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Enums;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    /// <summary>
    /// Represents a field definition within a data schema
    /// Similar to SectionItemField in Content system
    /// </summary>
    public class DataSchemaField : Entity<int>
    {
        /// <summary>
        /// Reference to the parent schema
        /// </summary>
        public int DataSchemaId { get; set; }

        /// <summary>
        /// Unique key for this field within the schema (e.g., "storage_gb", "screen_type", "brightness")
        /// </summary>
        public string FieldKey { get; set; } = string.Empty;

        /// <summary>
        /// Display name for this field (e.g., "Storage (GB)", "Screen Type", "Brightness")
        /// </summary>
        public string FieldName { get; set; } = string.Empty;

        /// <summary>
        /// Field description for help text
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Type of field (Text, Number, Boolean, Select, etc.)
        /// </summary>
        public DataSchemaFieldType Type { get; set; } = DataSchemaFieldType.Text;

        /// <summary>
        /// Whether this field is required when creating products
        /// </summary>
        public bool IsRequired { get; set; } = false;

        /// <summary>
        /// Whether this field supports multiple languages
        /// </summary>
        public bool IsTranslatable { get; set; } = false;

        /// <summary>
        /// Whether this field should be shown in product listings
        /// </summary>
        public bool ShowInListing { get; set; } = true;

        /// <summary>
        /// Whether this field should be shown in product details
        /// </summary>
        public bool ShowInDetails { get; set; } = true;

        /// <summary>
        /// Whether this field can be used for filtering
        /// </summary>
        public bool IsFilterable { get; set; } = false;

        /// <summary>
        /// Whether this field can be used for sorting
        /// </summary>
        public bool IsSortable { get; set; } = false;

        /// <summary>
        /// Default value for this field
        /// </summary>
        public string? DefaultValue { get; set; }

        /// <summary>
        /// Placeholder text for input fields
        /// </summary>
        public string? Placeholder { get; set; }

        /// <summary>
        /// JSON string containing options for select/radio fields
        /// Format: [{"value": "128GB", "label": "128 GB"}, {"value": "256GB", "label": "256 GB"}]
        /// </summary>
        public string? OptionsJson { get; set; }

        /// <summary>
        /// Validation rules in JSON format
        /// Format: {"min": 0, "max": 1000, "pattern": "^[0-9]+$"}
        /// </summary>
        public string? ValidationRules { get; set; }

        /// <summary>
        /// Unit of measurement (e.g., "GB", "inches", "nits", "MP")
        /// </summary>
        public string? Unit { get; set; }

        /// <summary>
        /// Display order for this field
        /// </summary>
        public int SortOrder { get; set; } = 0;

        /// <summary>
        /// Whether this field is active and should be shown in UI
        /// </summary>
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        /// <summary>
        /// Parent data schema
        /// </summary>
        public virtual DataSchema DataSchema { get; set; } = null!;

        /// <summary>
        /// Field values for products using this field
        /// </summary>
        public virtual ICollection<DataSchemaFieldValue> FieldValues { get; set; } = new List<DataSchemaFieldValue>();

        /// <summary>
        /// Translations for this field
        /// </summary>
        public virtual ICollection<DataSchemaFieldTranslation> Translations { get; set; } = new List<DataSchemaFieldTranslation>();
    }
}