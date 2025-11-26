using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Application.Models.API.Request
{
    /// <summary>
    /// Query model for getting a single announcement by ID
    /// </summary>
    public class AnnouncementQuery
    {
        /// <summary>
        /// Announcement ID
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Culture code (e.g., "tr-TR", "en-US")
        /// </summary>
        [Required]
        public string Culture { get; set; } = "tr-TR";
    }
}
