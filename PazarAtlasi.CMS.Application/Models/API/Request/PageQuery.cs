using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Application.Models.API.Request
{
    public class PageQuery
    {
        [Required]
        public string Slug { get; set; } = string.Empty;

        [Required]
        public string Culture { get; set; } = "tr-TR";
    }
}