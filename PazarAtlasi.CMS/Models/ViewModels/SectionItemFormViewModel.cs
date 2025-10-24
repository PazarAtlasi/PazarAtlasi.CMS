using PazarAtlasi.CMS.Application.Dtos;
using PazarAtlasi.CMS.Application.Dtos;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// ViewModel for Section Item Form partial view
    /// </summary>
    public class SectionItemFormViewModel
    {
        public int TemplateId { get; set; }
        public int ItemId { get; set; }
        public int ParentItemId { get; set; }
        public bool IsNested { get; set; }
        public TemplateSettingDto? Configuration { get; set; }
        public SectionItemViewModel? Item { get; set; }
    }
}