using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Configuration/Template definition for section items
    /// Defines structure, fields, validation rules, and UI behavior
    /// </summary>
    public class SectionItemSetting : Entity<int>
    {
        /// <summary>
        /// Parent template this configuration belongs to
        /// </summary>
        public int TemplateId { get; set; }

        /// <summary>
        /// Unique key for this configuration within the template (e.g., "logo", "menu", "dropdown-link")
        /// </summary>
        public string ConfigurationKey { get; set; } = string.Empty;

        /// <summary>
        /// Type of item this configuration represents
        /// </summary>
        public SectionItemType ItemType { get; set; }

        /// <summary>
        /// Minimum number of items allowed
        /// </summary>
        public int MinItems { get; set; } = 0;

        /// <summary>
        /// Maximum number of items allowed (null = unlimited)
        /// </summary>
        public int? MaxItems { get; set; }

        /// <summary>
        /// Default number of items to create
        /// </summary>
        public int DefaultItemCount { get; set; } = 1;

        /// <summary>
        /// Whether users can add/remove items dynamically
        /// </summary>
        public bool AllowDynamicSectionItems { get; set; } = true;

        /// <summary>
        /// JSON configuration for UI behavior (layout, icons, labels, etc.)
        /// </summary>
        public string? UIConfigurationJson { get; set; }

        /// <summary>
        /// Display order for this configuration
        /// </summary>
        public int SortOrder { get; set; } = 0;

        /// <summary>
        /// Parent configuration ID for nested items
        /// </summary>
        public int? ParentSettingId { get; set; }

        public virtual SectionItemSetting? ParentSetting { get; set; }

        public virtual Template Template { get; set; } = null!;

        // Navigation properties
        /// <summary>
        /// Field configurations for this item
        /// </summary>
        public virtual ICollection<SectionItemFieldSetting> Fields { get; set; } = new List<SectionItemFieldSetting>();

        /// <summary>
        /// Translations for this configuration (titles, descriptions in different languages)
        /// </summary>
        public virtual ICollection<SectionItemSettingTranslation> Translations { get; set; } = new List<SectionItemSettingTranslation>();

        /// <summary>
        /// Child configurations (for nested items)
        /// </summary>
        public virtual ICollection<SectionItemSetting> ChildSettings { get; set; } = new List<SectionItemSetting>();

        /// <summary>
        /// Actual section items using this configuration
        /// </summary>
        public virtual ICollection<SectionItem> SectionItems { get; set; } = new List<SectionItem>();
    }
}

