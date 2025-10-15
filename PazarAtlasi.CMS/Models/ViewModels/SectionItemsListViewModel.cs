using PazarAtlasi.CMS.Application.Dtos;
using PazarAtlasi.CMS.Infrastructure.Services;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// ViewModel for Section Items List partial view
    /// </summary>
    public class SectionItemsListViewModel
    {
        public int TemplateId { get; set; }
        public int SectionId { get; set; }
        public TemplateConfigurationDto? Configuration { get; set; }
        public List<SectionItemViewModel> SectionItems { get; set; } = new();
    }
}