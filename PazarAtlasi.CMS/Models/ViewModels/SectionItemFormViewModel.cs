using PazarAtlasi.CMS.Application.Dtos;
using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// Unified ViewModel for SectionItem Create/Edit operations
    /// </summary>
    public class SectionItemFormViewModel
    {
        public SectionItemUpdateDto SectionItem { get; set; } = new();
        
        // Form metadata
        public bool IsEditMode => SectionItem.Id > 0;
        public string FormTitle => IsEditMode ? "Edit Section Item" : "Create Section Item";
        public string SubmitButtonText => IsEditMode ? "Update Section Item" : "Create Section Item";
        public string FormAction => IsEditMode ? "SectionItemEdit" : "SectionItemCreate";
        
        // Dropdown data
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();
        public List<string> SectionItemTypes { get; set; } = new();
        public List<string> MediaTypes { get; set; } = new();
        public List<TemplateDto> Templates { get; set; } = new();
        public List<SectionItemDto> ParentSectionItems { get; set; } = new();
        
        // Nested structure data
        public SectionItemDto? ParentItem { get; set; }
        public List<SectionItemDto> ChildItems { get; set; } = new();
        public bool ShowNestedStructure => IsEditMode && (ParentItem != null || ChildItems.Any());
        
        // Additional properties for better UX
        public string? SuccessMessage { get; set; }
        public string? ErrorMessage { get; set; }
        public bool ShowTemplatePreview { get; set; } = true;
        public bool ShowFieldsSection => IsEditMode && SectionItem.Fields.Any();
        public bool ShowFieldValuesSection => IsEditMode && SectionItem.FieldValues.Any();
    }
}