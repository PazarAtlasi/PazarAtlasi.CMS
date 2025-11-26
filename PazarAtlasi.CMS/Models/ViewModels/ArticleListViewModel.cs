using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class ArticleListViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? CategoryName { get; set; }
        public string? FeaturedImage { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsTrending { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ArticleListResponse
    {
        public List<ArticleListViewModel> Articles { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
