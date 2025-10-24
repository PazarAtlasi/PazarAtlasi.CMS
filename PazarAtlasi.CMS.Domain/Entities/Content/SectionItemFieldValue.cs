using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Stores the actual values for section item fields
    /// Links a specific section item to a field definition with its value
    /// </summary>
    public class SectionItemFieldValue : Entity<int>
    {
        /// <summary>
        /// Reference to the section item this value belongs to
        /// </summary>
        public int SectionItemId { get; set; }

        /// <summary>
        /// Reference to the field definition
        /// </summary>
        public int SectionItemFieldId { get; set; }

        /// <summary>
        /// The actual value for this field (for non-translatable fields)
        /// For translatable fields, this can be the default language value
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// JSON data for complex field types (arrays, objects, etc.)
        /// </summary>
        public string? JsonValue { get; set; }

        // Navigation properties
        public virtual SectionItem SectionItem { get; set; } = null!;
        public virtual SectionItemField SectionItemField { get; set; } = null!;
        public virtual ICollection<SectionItemFieldValueTranslation> Translations { get; set; } = new List<SectionItemFieldValueTranslation>();
    }
}