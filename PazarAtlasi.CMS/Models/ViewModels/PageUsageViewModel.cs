using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class PageUsageViewModel
    {
        public int PageId { get; set; }
        public string? PageName { get; set; }
        public string? PageCode { get; set; }
        public PageType PageType { get; set; }
        public Status PageStatus { get; set; }
    }
}
