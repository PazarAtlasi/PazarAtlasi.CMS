using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Application.Models.API.Request
{
    public class SectionQuery
    {
        [Required]
        public int SectionId { get; set; }

        [Required]
        public string Culture { get; set; } = "tr-TR";
    }
}