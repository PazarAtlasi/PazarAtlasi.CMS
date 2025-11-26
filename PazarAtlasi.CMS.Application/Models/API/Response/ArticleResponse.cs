using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Application.Models.API.Response
{
    /// <summary>
    /// Response model for a single article with full details
    /// </summary>
    public class ArticleResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Summary { get; set; }
        public string? Content { get; set; }
        public string? FeaturedImage { get; set; }
        public string? VideoUrl { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsTrending { get; set; }
        public int? ReadingTime { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public Status Status { get; set; }
        
        // Category information
        public ArticleCategoryResponse? Category { get; set; }
        
        // SEO information
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        
        // Related articles
        public List<ArticleListItemResponse> RelatedArticles { get; set; } = new List<ArticleListItemResponse>();
        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// Response model for article list item (summary view)
    /// </summary>
    public class ArticleListItemResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Summary { get; set; }
        public string? FeaturedImage { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsTrending { get; set; }
        public int? ReadingTime { get; set; }
        public string? CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryColor { get; set; }
        public string? CategoryIcon { get; set; }
    }

    /// <summary>
    /// Response model for paginated article list
    /// </summary>
    public class ArticleListResponse
    {
        public List<ArticleListItemResponse> Articles { get; set; } = new List<ArticleListItemResponse>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }

    /// <summary>
    /// Response model for article category
    /// </summary>
    public class ArticleCategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public string? Color { get; set; }
        public int? ParentCategoryId { get; set; }
        public int ArticleCount { get; set; }
        public List<ArticleCategoryResponse> ChildCategories { get; set; } = new List<ArticleCategoryResponse>();
    }

    /// <summary>
    /// Response model for article categories list
    /// </summary>
    public class ArticleCategoryListResponse
    {
        public List<ArticleCategoryResponse> Categories { get; set; } = new List<ArticleCategoryResponse>();
    }
}
