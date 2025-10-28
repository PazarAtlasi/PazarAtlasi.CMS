using PazarAtlasi.CMS.Domain.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PazarAtlasi.CMS.Application.Dtos
{
    public class SectionItemDto
    {
        public int Id { get; set; }
        public int? ParentSectionItemId { get; set; }
        public int? TemplateId { get; set; }
        public string? TemplateName { get; set; }
        public SectionItemType Type { get; set; }
        public MediaType MediaType { get; set; }
        public int SortOrder { get; set; }
        public string? Title { get; set; }
        public string? Key { get; set; }
        public string? Description { get; set; }
        public bool AllowReorder { get; set; }
        public bool AllowRemove { get; set; }
        public string? IconClass { get; set; }
        public bool IsChild { get; set; } = false;
        public string? ParentTitle { get; set; }
        public int Level { get; set; } = 0; // For tree view indentation
        public bool HasChildren { get; set; } = false;
        public List<SectionItemDto> Children { get; set; } = new List<SectionItemDto>();
        public List<SectionItemTranslationDto> Translations { get; set; } = new List<SectionItemTranslationDto>();
        public List<SectionItemFieldDto> Fields { get; set; } = new List<SectionItemFieldDto>();
        public List<SectionItemFieldValueDto> FieldValues { get; set; } = new List<SectionItemFieldValueDto>();
    }

    public class SectionItemTranslationDto
    {
        public int Id { get; set; }
        public int SectionItemId { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }

    public class SectionItemFieldDto
    {
        public int Id { get; set; }
        public int SectionItemId { get; set; }
        public string FieldKey { get; set; } = string.Empty;
        public string FieldName { get; set; } = string.Empty;
        public SectionItemFieldType Type { get; set; }
        public bool Required { get; set; }
        public int? MaxLength { get; set; }
        public string? Placeholder { get; set; }
        public string? DefaultValue { get; set; }
        public bool IsTranslatable { get; set; }
        public bool ShowInUI { get; set; } = true;
        public string? OptionsJson { get; set; }
        public int SortOrder { get; set; }
        public List<SectionItemFieldTranslationDto> Translations { get; set; } = new List<SectionItemFieldTranslationDto>();
    }

    public class SectionItemFieldTranslationDto
    {
        public int Id { get; set; }
        public int SectionItemFieldId { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public string Label { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Placeholder { get; set; }
    }

    public class SectionItemFieldValueDto
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int SectionItemId { get; set; }
        public int SectionItemFieldId { get; set; }
        public string Value { get; set; } = string.Empty;
        public string? JsonValue { get; set; }
        public List<SectionItemFieldValueTranslationDto> Translations { get; set; } = new List<SectionItemFieldValueTranslationDto>();
    }

    public class SectionItemFieldValueTranslationDto
    {
        public int Id { get; set; }
        public int SectionItemFieldValueId { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public string Value { get; set; } = string.Empty;
        public string? JsonValue { get; set; }
    }

    public class SectionItemUpdateDto
    {
        public int Id { get; set; }
        public int? ParentSectionItemId { get; set; }
        public int? TemplateId { get; set; }
        public SectionItemType Type { get; set; }
        public MediaType MediaType { get; set; }
        public int SortOrder { get; set; }
        public string? Title { get; set; }
        public string? Key { get; set; }
        public string? Description { get; set; }
        public bool AllowReorder { get; set; }
        public bool AllowRemove { get; set; }
        public string? IconClass { get; set; }
        public List<SectionItemTranslationUpdateDto> Translations { get; set; } = new List<SectionItemTranslationUpdateDto>();
        public List<SectionItemFieldUpdateDto> Fields { get; set; } = new List<SectionItemFieldUpdateDto>();
        public List<SectionItemFieldValueUpdateDto> FieldValues { get; set; } = new List<SectionItemFieldValueUpdateDto>();
    }

    public class SectionItemTranslationUpdateDto
    {
        public int Id { get; set; }
        public int SectionItemId { get; set; }
        public int LanguageId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }

    public class SectionItemFieldUpdateDto
    {
        public int Id { get; set; }
        public int SectionItemId { get; set; }
        public string FieldKey { get; set; } = string.Empty;
        public string? FieldName { get; set; } = string.Empty;
        public SectionItemFieldType Type { get; set; }
        public bool Required { get; set; }
        public int? MaxLength { get; set; }
        public string? Placeholder { get; set; }
        public string? DefaultValue { get; set; }
        public bool IsTranslatable { get; set; }
        public bool ShowInUI { get; set; } = true;
        public string? OptionsJson { get; set; }
        public int SortOrder { get; set; }
        public List<SectionItemFieldTranslationUpdateDto> Translations { get; set; } = new List<SectionItemFieldTranslationUpdateDto>();
        
        // SelectList için field types
        public List<SelectListItem> FieldTypes { get; set; } = new List<SelectListItem>();
    }

    public class SectionItemFieldTranslationUpdateDto
    {
        public int Id { get; set; }
        public int SectionItemFieldId { get; set; }
        public int LanguageId { get; set; }
        public string? Label { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Placeholder { get; set; }
    }

    public class SectionItemFieldValueUpdateDto
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public int SectionItemId { get; set; }
        public int SectionItemFieldId { get; set; }
        public string Value { get; set; } = string.Empty;
        public string? JsonValue { get; set; }
        public List<SectionItemFieldValueTranslationUpdateDto> Translations { get; set; } = new List<SectionItemFieldValueTranslationUpdateDto>();
    }

    public class SectionItemFieldValueTranslationUpdateDto
    {
        public int Id { get; set; }
        public int SectionItemFieldValueId { get; set; }
        public int LanguageId { get; set; }
        public string Value { get; set; } = string.Empty;
        public string? JsonValue { get; set; }
    }
}
