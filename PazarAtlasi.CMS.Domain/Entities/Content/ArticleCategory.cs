using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    /// <summary>
    /// Article category/topic
    /// </summary>
    public class ArticleCategory : Entity<int>
    {
        /// <summary>
        /// Parent category ID for hierarchical structure
        /// </summary>
        public int? ParentCategoryId { get; set; }

        /// <summary>
        /// Category icon/image
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// Category color (hex code)
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// Sort order for display
        /// </summary>
        public int SortOrder { get; set; } = 0;

        // Navigation Properties
        public virtual ArticleCategory? ParentCategory { get; set; }
        public virtual ICollection<ArticleCategory> ChildCategories { get; set; } = new List<ArticleCategory>();
        public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
        public virtual ICollection<ArticleCategoryTranslation> Translations { get; set; } = new List<ArticleCategoryTranslation>();
    }
}
