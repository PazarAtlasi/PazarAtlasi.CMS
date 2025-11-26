using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Translation entity for ArticleCategory
    /// </summary>
    public class ArticleCategoryTranslation : Entity<int>
    {
        public int ArticleCategoryId { get; set; }
        public int LanguageId { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Category description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// URL slug
        /// </summary>
        public string? Slug { get; set; }

        // Navigation Properties
        public virtual ArticleCategory ArticleCategory { get; set; } = null!;
        public virtual Language Language { get; set; } = null!;
    }
}
