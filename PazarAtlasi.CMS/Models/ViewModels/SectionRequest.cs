using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// Request model for creating/updating sections with items via AJAX
    /// </summary>
    public class SectionRequest
    {
        public int Id { get; set; }

        public int PageId { get; set; }
        
        public object? TemplateConfiguration { get; set; } // Will be deserialized from JSON
        
        public SectionType Type { get; set; }
        
        public string? Attributes { get; set; }
        
        public int SortOrder { get; set; }
        
        public string? Configure { get; set; }
        
        public Status Status { get; set; }
        
        public List<SectionItemRequest> SectionItems { get; set; } = new();
        
        public List<SectionTranslationRequest> Translations { get; set; } = new();
    }
}
