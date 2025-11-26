using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Application.Models.API.Request
{
    /// <summary>
    /// Query model for getting article categories
    /// </summary>
    public class ArticleCategoryQuery
    {
        /// <summary>
        /// Culture code (e.g., "tr-TR", "en-US")
        /// </summary>
        [Required]
        public string Culture { get; set; } = "tr-TR";

        /// <summary>
        /// Include article count for each category
        /// </summary>
        public bool IncludeArticleCount { get; set; } = true;

        /// <summary>
        /// Include child categories
        /// </summary>
        public bool IncludeChildren { get; set; } = true;
    }
}
