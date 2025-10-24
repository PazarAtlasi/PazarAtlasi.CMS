using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Stores translated values for section item fields
    /// Enables multi-language support for field values
    /// </summary>
    public class SectionItemFieldValueTranslation : Entity<int>
    {
        /// <summary>
        /// Reference to the field value this translation belongs to
        /// </summary>
        public int SectionItemFieldValueId { get; set; }

        /// <summary>
        /// Language ID for this translation
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Translated value for this field in the specified language
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// JSON data for complex translated values
        /// </summary>
        public string? JsonValue { get; set; }

        // Navigation properties
        public virtual SectionItemFieldValue SectionItemFieldValue { get; set; } = null!;
        public virtual Language Language { get; set; } = null!;
    }
}