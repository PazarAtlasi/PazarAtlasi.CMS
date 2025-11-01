using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Application.Models.API.Response
{
    public class LayoutSectionsResponse
    {
        public int LayoutId { get; set; }
        public string LayoutName { get; set; } = string.Empty;
        public List<SectionResponse> HeaderSections { get; set; } = new List<SectionResponse>();
        public List<SectionResponse> ContentSections { get; set; } = new List<SectionResponse>();
        public List<SectionResponse> SidebarSections { get; set; } = new List<SectionResponse>();
        public List<SectionResponse> FooterSections { get; set; } = new List<SectionResponse>();
    }
}