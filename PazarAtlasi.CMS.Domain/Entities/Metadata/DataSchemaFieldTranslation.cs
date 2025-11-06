using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    /// <summary>
    /// Translation entity for DataSchemaField
    /// </summary>
    public class DataSchemaFieldTranslation : Entity<int>
    {
        /// <summary>
        /// Reference to the data schema field
        /// </summary>
        public int DataSchemaFieldId { get; set; }

        /// <summary>
        /// Reference to the language
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Translated field name
        /// </summary>
        public string FieldName { get; set; } = string.Empty;

        /// <summary>
        /// Translated field description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Translated placeholder text
        /// </summary>
        public string? Placeholder { get; set; }

        /// <summary>
        /// Translated unit of measurement
        /// </summary>
        public string? Unit { get; set; }

        /// <summary>
        /// Translated options for select fields (JSON format)
        /// </summary>
        public string? OptionsJson { get; set; }

        // Navigation Properties
        /// <summary>
        /// Parent data schema field
        /// </summary>
        public virtual DataSchemaField DataSchemaField { get; set; } = null!;

        /// <summary>
        /// Language for this translation
        /// </summary>
        public virtual Language Language { get; set; } = null!;
    }
}