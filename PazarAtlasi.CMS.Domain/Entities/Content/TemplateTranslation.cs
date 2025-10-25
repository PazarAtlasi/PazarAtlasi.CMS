using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Stores translated values for Template metadata (Name, Description)
    /// Enables multi-language support for template definitions
    /// </summary>
    public class TemplateTranslation : Entity<int>
    {
        /// <summary>
        /// Reference to the template this translation belongs to
        /// </summary>
        public int TemplateId { get; set; }

        /// <summary>
        /// Language ID for this translation
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Translated name for this template in the specified language
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Translated description for this template in the specified language
        /// </summary>
        public string? Description { get; set; }

        // Navigation properties
        public virtual Template Template { get; set; } = null!;
        public virtual Language Language { get; set; } = null!;
    }
}
