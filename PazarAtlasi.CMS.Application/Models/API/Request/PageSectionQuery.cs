using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Application.Models.API.Request
{
    public class PageSectionQuery
    {
        [Required]
        public int PageId { get; set; }

        [Required]
        public string Culture { get; set; } = "tr-TR";
    }
}