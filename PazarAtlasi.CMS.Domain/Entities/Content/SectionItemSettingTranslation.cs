using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Translation for section item configuration (UI labels and descriptions)
    /// </summary>
    public class SectionItemSettingTranslation : Entity<int>
    {
        /// <summary>
        /// Section item configuration this translation belongs to
        /// </summary>
        public int SectionItemSettingId { get; set; }
        public virtual SectionItemSetting SectionItemSetting { get; set; } = null!;

        /// <summary>
        /// Language for this translation
        /// </summary>
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; } = null!;

        /// <summary>
        /// Display title for this item type (e.g., "Menu Item", "Dropdown Link")
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Description explaining what this item type is for
        /// </summary>
        public string? Description { get; set; }
    }
}
