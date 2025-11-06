using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    /// <summary>
    /// Translation entity for DataSchema
    /// </summary>
    public class DataSchemaTranslation : Entity<int>
    {
        /// <summary>
        /// Reference to the data schema
        /// </summary>
        public int DataSchemaId { get; set; }

        /// <summary>
        /// Reference to the language
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Translated name of the schema
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Translated description of the schema
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Translated category name
        /// </summary>
        public string? Category { get; set; }

        // Navigation Properties
        /// <summary>
        /// Parent data schema
        /// </summary>
        public virtual DataSchema DataSchema { get; set; } = null!;

        /// <summary>
        /// Language for this translation
        /// </summary>
        public virtual Language Language { get; set; } = null!;
    }
}