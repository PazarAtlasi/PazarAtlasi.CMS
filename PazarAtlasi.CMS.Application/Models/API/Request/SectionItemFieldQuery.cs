using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Application.Models.API.Request
{
    public class SectionItemFieldQuery
    {
        [Required]
        public int SectionItemFieldId { get; set; }

        [Required]
        public string Culture { get; set; } = "tr-TR";
    }
}