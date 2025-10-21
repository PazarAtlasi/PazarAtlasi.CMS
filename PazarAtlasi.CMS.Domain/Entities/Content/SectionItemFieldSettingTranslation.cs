using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Translation for field configuration (labels and descriptions in different languages)
    /// </summary>
    public class SectionItemFieldSettingTranslation : Entity<int>
    {
        /// <summary>
        /// Field configuration this translation belongs to
        /// </summary>
        public int SectionItemFieldSettingId { get; set; }
        public virtual SectionItemFieldSetting SectionItemFieldSetting { get; set; } = null!;

        /// <summary>
        /// Language for this translation
        /// </summary>
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; } = null!;

        /// <summary>
        /// Display label for this field (e.g., "Logo Image", "Menu Title")
        /// </summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// Description/help text for this field
        /// </summary>
        public string? Description { get; set; }
    }
}
