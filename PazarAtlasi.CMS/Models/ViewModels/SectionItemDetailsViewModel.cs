using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class SectionItemDetailsViewModel
    {
        public SectionItemDetailsViewModel()
        {
        }

        public int Id { get; set; }
        public SectionItemType Type { get; set; }
        public MediaType MediaType { get; set; }
        public string? PictureUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string? RedirectUrl { get; set; }
        public string? Icon { get; set; }
        public int SortOrder { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
