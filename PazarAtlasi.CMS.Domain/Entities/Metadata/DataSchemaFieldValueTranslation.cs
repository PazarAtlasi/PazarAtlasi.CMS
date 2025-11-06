using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    /// <summary>
    /// Translation entity for DataSchemaFieldValue
    /// </summary>
    public class DataSchemaFieldValueTranslation : Entity<int>
    {
        /// <summary>
        /// Reference to the data schema field value
        /// </summary>
        public int DataSchemaFieldValueId { get; set; }

        /// <summary>
        /// Reference to the language
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Translated value
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// Translated JSON value for complex data
        /// </summary>
        public string? JsonValue { get; set; }

        // Navigation Properties
        /// <summary>
        /// Parent data schema field value
        /// </summary>
        public virtual DataSchemaFieldValue DataSchemaFieldValue { get; set; } = null!;

        /// <summary>
        /// Language for this translation
        /// </summary>
        public virtual Language Language { get; set; } = null!;
    }
}