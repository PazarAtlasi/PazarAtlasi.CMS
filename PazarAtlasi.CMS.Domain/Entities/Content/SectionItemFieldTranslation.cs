using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Translations for SectionItemField metadata (labels, descriptions, etc.)
    /// Enables multi-language support for field definitions
    /// </summary>
    public class SectionItemFieldTranslation : Entity<int>
    {
        /// <summary>
        /// Reference to the field definition
        /// </summary>
        public int SectionItemFieldId { get; set; }

        /// <summary>
        /// Language for this translation
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Translated field label (displayed in UI)
        /// </summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// Translated field description/help text
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Translated placeholder text
        /// </summary>
        public string? Placeholder { get; set; }

        // Navigation properties
        public virtual SectionItemField SectionItemField { get; set; } = null!;
        public virtual Language Language { get; set; } = null!;
    }
}