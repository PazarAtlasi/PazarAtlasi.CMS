using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Application.Models.API.Request
{
    /// <summary>
    /// Query model for getting article list with filtering and pagination
    /// </summary>
    public class ArticleListQuery
    {
        /// <summary>
        /// Culture code (e.g., "tr-TR", "en-US")
        /// </summary>
        [Required]
        public string Culture { get; set; } = "tr-TR";

        /// <summary>
        /// Page number (1-based)
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;

        /// <summary>
        /// Page size (number of articles per page)
        /// </summary>
        [Range(1, 100)]
        public int PageSize { get; set; } = 12;

        /// <summary>
        /// Filter by category ID (optional)
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Filter by featured articles only
        /// </summary>
        public bool? IsFeatured { get; set; }

        /// <summary>
        /// Filter by trending articles only
        /// </summary>
        public bool? IsTrending { get; set; }

        /// <summary>
        /// Search term for title and content
        /// </summary>
        public string? SearchTerm { get; set; }

        /// <summary>
        /// Sort by: "latest", "popular", "trending", "oldest"
        /// </summary>
        public string SortBy { get; set; } = "latest";
    }
}
