using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// Request model for creating/updating section items via AJAX
    /// </summary>
    public class SectionItemRequest
    {
        public int Id { get; set; }

        public int SectionId { get; set; }
        
        public SectionItemType Type { get; set; }
        
        public MediaType MediaType { get; set; }
        
        public int? SelectedOptionId { get; set; } // will be used for dropdowns or option selections

        public int SortOrder { get; set; }
        
        public Status Status { get; set; }
        
        public List<SectionItemFieldViewModel>? Fields { get; set; } = new();
        
        public List<SectionItemRequest> NestedItems { get; set; } = new();
        
        public List<SectionItemTranslationRequest> Translations { get; set; } = new();
    }
}

