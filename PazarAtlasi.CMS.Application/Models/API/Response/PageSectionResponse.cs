using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Application.Models.API.Response
{
    public class PageSectionResponse
    {
        public int PageId { get; set; }
        public string PageName { get; set; } = string.Empty;
        public string PageSlug { get; set; } = string.Empty;
        public List<SectionResponse> Sections { get; set; } = new List<SectionResponse>();
    }
}