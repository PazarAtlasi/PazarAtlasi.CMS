using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Application.Models.API.Request
{
    /// <summary>
    /// Query model for getting announcement list with filtering and pagination
    /// </summary>
    public class AnnouncementListQuery
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
        /// Page size (number of announcements per page)
        /// </summary>
        [Range(1, 100)]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Filter by active announcements only (within publish date range)
        /// </summary>
        public bool? OnlyActive { get; set; }

        /// <summary>
        /// Search term for title and content
        /// </summary>
        public string? SearchTerm { get; set; }
    }
}
