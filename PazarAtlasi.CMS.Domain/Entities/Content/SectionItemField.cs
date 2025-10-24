using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Represents a field definition for templates (metadata only, no values)
    /// Defines what fields are available for section items created from a template
    /// </summary>
    public class SectionItemField : Entity<int>
    {
        public int SectionItemId { get; set; }

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
        /// Maximum length for text fields
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// Placeholder text for the field
        /// </summary>
        public string? Placeholder { get; set; }

        /// <summary>
        /// Default value for the field
        /// </summary>
        public string? DefaultValue { get; set; }

        /// <summary>
        /// Whether this field supports multiple languages
        /// </summary>
        public bool IsTranslatable { get; set; } = false;

        /// <summary>
        /// JSON string containing options for select/radio fields
        /// </summary>
        public string? OptionsJson { get; set; }

        /// <summary>
        /// Display order for this field
        /// </summary>
        public int SortOrder { get; set; } = 0;

        // Navigation properties
        public virtual SectionItem SectionItem { get; set; } = null!;
        
        /// <summary>
        /// Field values created from this field definition
        /// </summary>
        public virtual ICollection<SectionItemFieldValue> SectionItemFieldValues { get; set; } = new List<SectionItemFieldValue>();
        
        /// <summary>
        /// Translations for this field definition (labels, descriptions, etc.)
        /// </summary>
        public virtual ICollection<SectionItemFieldTranslation> Translations { get; set; } = new List<SectionItemFieldTranslation>();
    }
}