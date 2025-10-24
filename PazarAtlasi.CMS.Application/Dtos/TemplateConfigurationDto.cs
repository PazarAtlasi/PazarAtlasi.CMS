using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Application.Dtos
{
    /// <summary>
    /// Template configuration that defines how section items should be rendered
    /// </summary>
    public class TemplateSettingDto
    {
        public int TemplateId { get; set; }

        public string TemplateName { get; set; } = string.Empty;
            
        public string TemplateKey { get; set; } = string.Empty;

        /// <summary>
        /// Section item configuration for this template
        /// </summary>
        public SectionItemSettingDto SectionItemSetting { get; set; } = new();
    }

    /// <summary>
    /// Configuration for a section item type (recursive structure for nested items)
    /// </summary>
    public class SectionItemSettingDto
    {
        /// <summary>
        /// Whether user can add/remove items of this type dynamically
        /// </summary>
        public bool AllowDynamicSectionItems { get; set; } = true;

        /// <summary>
        /// Item type
        /// </summary>
        public SectionItemType ItemType { get; set; }

        /// <summary>
        /// Media type if item type is media-based
        /// </summary>
        public MediaType? MediaType { get; set; }

        /// <summary>
        /// Translations for this item configuration
        /// </summary>
        public List<SectionItemSettingTranslationDto> Translations { get; set; } = new();

        /// <summary>
        /// Field definitions for this item type (no values, only metadata)
        /// </summary>
        public List<SectionItemFieldSettingDto> Fields { get; set; } = new();

        /// <summary>
        /// Nested item configurations (recursive - for dropdown menus, etc.)
        /// Can be empty or contain multiple nested configurations
        /// </summary>
        public List<SectionItemSettingDto> ChildSectionItemSettings { get; set; } = new();

        /// <summary>
        /// UI rendering configuration for this item type
        /// </summary>
        public SectionItemUISettingDto UIConfiguration { get; set; } = new();
    }

    /// <summary>
    /// Translation data for section item configuration
    /// </summary>
    public class SectionItemSettingTranslationDto
    {
        public int LanguageId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
    }

    /// <summary>
    /// Field definition for section item (metadata only, no values)
    /// </summary>
    public class SectionItemFieldSettingDto
    {
        /// <summary>
        /// Unique key for this field (e.g., "title", "url", "image")
        /// </summary>
        public string FieldKey { get; set; } = string.Empty;

        /// <summary>
        /// Field type (Text, Image, URL, etc.)
        /// </summary>
        public SectionItemFieldType Type { get; set; }
        
        /// <summary>
        /// Is this field required?
        /// </summary>
        public bool Required { get; set; } = false;
        
        /// <summary>
        /// Placeholder text for UI
        /// </summary>
        public string? Placeholder { get; set; }
        
        /// <summary>
        /// Maximum length for text fields
        /// </summary>
        public int? MaxLength { get; set; }
        
        /// <summary>
        /// Options for select/dropdown fields
        /// </summary>
        public List<string>? Options { get; set; }
        
        /// <summary>
        /// Default value for this field
        /// </summary>
        public string? DefaultValue { get; set; }
        
        /// <summary>
        /// Whether this field supports multiple languages/translations
        /// </summary>
        public bool IsTranslatable { get; set; } = false;

        /// <summary>
        /// Translations for this field (Label, Description in different languages)
        /// </summary>
        public List<SectionItemFieldTranslationDto> Translations { get; set; } = new();
    }

    /// <summary>
    /// Translation data for field metadata (label, description)
    /// </summary>
    public class SectionItemFieldTranslationDto
    {
        public int LanguageId { get; set; }

        public string? Label { get; set; }

        public string? Description { get; set; }
    }

    /// <summary>
    /// UI rendering configuration for items
    /// </summary>
    public class SectionItemUISettingDto
    {
        public string Layout { get; set; } = "grid"; // grid, list, carousel
        
        public int Columns { get; set; } = 3;
        
        public bool ShowPreview { get; set; } = true;
        
        public bool ShowReorder { get; set; } = true;
        
        public string AddButtonText { get; set; } = "Add Item";
        
        public string? IconClass { get; set; }
    }
}
