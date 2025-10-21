using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Field configuration for a section item
    /// Defines field type, validation, and UI properties
    /// </summary>
    public class SectionItemFieldSetting : Entity<int>
    {
        /// <summary>
        /// Parent section item configuration
        /// </summary>
        public int SectionItemSettingId { get; set; }
        public virtual SectionItemSetting SectionItemSetting { get; set; } = null!;

        /// <summary>
        /// Unique key for this field (e.g., "image", "title", "url")
        /// </summary>
        public string FieldKey { get; set; } = string.Empty;

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
        /// <summary>
        /// Translations for this field (labels, descriptions in different languages)
        /// </summary>
        public virtual ICollection<SectionItemFieldSettingTranslation> Translations { get; set; } = new List<SectionItemFieldSettingTranslation>();
    }
}
