using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Represents a news article or blog post
    /// </summary>
    public class Article : Entity<int>
    {
        /// <summary>
        /// Article category
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Author user ID
        /// </summary>
        public int? AuthorId { get; set; }

        /// <summary>
        /// Featured image URL
        /// </summary>
        public string? FeaturedImage { get; set; }

        /// <summary>
        /// Video URL (optional)
        /// </summary>
        public string? VideoUrl { get; set; }

        /// <summary>
        /// Published date
        /// </summary>
        public DateTime? PublishedAt { get; set; }

        /// <summary>
        /// View count
        /// </summary>
        public int ViewCount { get; set; } = 0;

        /// <summary>
        /// Like count
        /// </summary>
        public int LikeCount { get; set; } = 0;

        /// <summary>
        /// Is featured article?
        /// </summary>
        public bool IsFeatured { get; set; } = false;

        /// <summary>
        /// Is trending article?
        /// </summary>
        public bool IsTrending { get; set; } = false;

        /// <summary>
        /// Reading time in minutes
        /// </summary>
        public int? ReadingTime { get; set; }

        /// <summary>
        /// Tags (JSON array)
        /// </summary>
        public string? Tags { get; set; }

        /// <summary>
        /// SEO meta description
        /// </summary>
        public string? MetaDescription { get; set; }

        /// <summary>
        /// SEO meta keywords
        /// </summary>
        public string? MetaKeywords { get; set; }

        /// <summary>
        /// Sort order for display
        /// </summary>
        public int SortOrder { get; set; } = 0;

        // Navigation Properties
        public virtual ArticleCategory? Category { get; set; }
        public virtual ICollection<ArticleTranslation> Translations { get; set; } = new List<ArticleTranslation>();
    }
}
