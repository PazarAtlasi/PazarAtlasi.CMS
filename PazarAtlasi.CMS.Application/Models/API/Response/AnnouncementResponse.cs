using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Application.Models.API.Response
{
    /// <summary>
    /// Response model for a single announcement with full details
    /// </summary>
    public class AnnouncementResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? Summary { get; set; }
        public string? CoverImage { get; set; }
        public DateTime PublishStart { get; set; }
        public DateTime PublishEnd { get; set; }
        public Status Status { get; set; }
        public string? CreatedByName { get; set; }
        public bool IsActive { get; set; } // Şu anda yayında mı?
        public int DaysRemaining { get; set; } // Yayın bitimine kalan gün sayısı
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// Response model for announcement list item (summary view)
    /// </summary>
    public class AnnouncementListItemResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Summary { get; set; }
        public string? CoverImage { get; set; }
        public DateTime PublishStart { get; set; }
        public DateTime PublishEnd { get; set; }
        public Status Status { get; set; }
        public bool IsActive { get; set; }
        public int DaysRemaining { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Response model for paginated announcement list
    /// </summary>
    public class AnnouncementListResponse
    {
        public List<AnnouncementListItemResponse> Announcements { get; set; } = new List<AnnouncementListItemResponse>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
