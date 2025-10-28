using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Application.Models.API.Request
{
    public class SectionQuery
    {
        [Required]
        public string Key { get; set; } = string.Empty;

        [Required]
        public string Culture { get; set; } = "tr-TR";
    }
}