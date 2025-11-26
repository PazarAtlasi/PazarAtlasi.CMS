using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Translation entity for Article
    /// </summary>
    public class ArticleTranslation : Entity<int>
    {
        public int ArticleId { get; set; }
        public int LanguageId { get; set; }

        /// <summary>
        /// Article title
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// URL slug
        /// </summary>
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Short summary/excerpt
        /// </summary>
        public string? Summary { get; set; }

        /// <summary>
        /// Full article content (HTML)
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// SEO meta title
        /// </summary>
        public string? MetaTitle { get; set; }

        // Navigation Properties
        public virtual Article Article { get; set; } = null!;
        public virtual Language Language { get; set; } = null!;
    }
}
