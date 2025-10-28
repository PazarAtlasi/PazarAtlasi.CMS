using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Application.Models.API.Request
{
    public class SectionItemQuery
    {
        [Required]
        public int SectionItemId { get; set; }

        [Required]
        public string Culture { get; set; } = "tr-TR";
    }
}