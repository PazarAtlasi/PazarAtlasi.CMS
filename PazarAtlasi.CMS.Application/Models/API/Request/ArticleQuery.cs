using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Application.Models.API.Request
{
    /// <summary>
    /// Query model for getting a single article by slug
    /// </summary>
    public class ArticleQuery
    {
        /// <summary>
        /// Article slug (URL-friendly identifier)
        /// </summary>
        [Required]
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Culture code (e.g., "tr-TR", "en-US")
        /// </summary>
        [Required]
        public string Culture { get; set; } = "tr-TR";
    }
}
