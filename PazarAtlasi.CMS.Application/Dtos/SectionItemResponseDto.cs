using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Application.Dtos
{
    public class SectionItemResponseDto
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public SectionItemType Type { get; set; }
        public MediaType MediaType { get; set; }
        public string? PictureUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string? RedirectUrl { get; set; }
        public string? Icon { get; set; }
        public int SortOrder { get; set; }
        public string? MediaAttributes { get; set; }
        public Status Status { get; set; }
        public List<SectionItemTranslationResponseDto> Translations { get; set; } = new();
    }
}
