using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Defines a field structure for section items
    /// Contains field definition, type, validation rules, etc.
    /// </summary>
    public class SectionItemField : Entity<int>
    {
        /// <summary>
        /// Template this field belongs to (optional, can be null for custom fields)
        /// </summary>
        public int? TemplateId { get; set; }

        /// <summary>
        /// Unique key for this field (e.g., "title", "image", "url")
        /// </summary>
        public string FieldKey { get; set; } = string.Empty;

        /// <summary>
        /// Display name for this field
        /// </summary>
        public string FieldName { get; set; } = string.Empty;

        /// <summary>
        /// Type of field (Text, Image, URL, etc.)
        /// </summary>
        public SectionItemFieldType Type { get; set; }

        /// <summary>
        /// Whether this field is required
        /// </summary>
        public bool Required { get; set; } = false;

        /// <summary>
        /// Maximum length for text fields (0 = no limit)
        /// </summary>
        public int MaxLength { get; set; } = 0;

        /// <summary>
        /// Placeholder text for the field
        /// </summary>
        public string? Placeholder { get; set; }

        /// <summary>
        /// Default value for the field
        /// </summary>
        public string? DefaultValue { get; set; }

        /// <summary>
        /// Whether this field supports multi-language input
        /// </summary>
        public bool IsTranslatable { get; set; } = false;

        /// <summary>
        /// JSON configuration for field options (e.g., select options, validation rules)
        /// </summary>
        public string? OptionsJson { get; set; }

        /// <summary>
        /// Display order for this field
        /// </summary>
        public int SortOrder { get; set; } = 0;

        // Navigation properties
        public virtual Template? Template { get; set; }
        
        /// <summary>
        /// Values for this field across different section items
        /// </summary>
        public virtual ICollection<SectionItemFieldValue> Values { get; set; } = new List<SectionItemFieldValue>();
    }
}