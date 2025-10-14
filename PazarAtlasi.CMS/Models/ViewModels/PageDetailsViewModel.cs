using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class PageDetailsViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public PageType PageType { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        // SEO Parameters
        public PageSEOParameterViewModel? SEOParameter { get; set; }
        
        // Sections
        public List<SectionViewModel> Sections { get; set; } = new();
        
        // Translations
        public List<PageTranslationViewModel> Translations { get; set; } = new();
    }
}
