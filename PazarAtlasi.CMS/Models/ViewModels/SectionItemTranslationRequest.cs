using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class SectionItemTranslationRequest
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string LanguageCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<SectionItemFieldRequest> Fields { get; set; } = new();
    }

    public class SectionItemFieldRequest
    {
        public string FieldKey { get; set; } = string.Empty;
        public string? FieldValue { get; set; }
        public SectionItemFieldType? FieldType { get; set; }
        public List<SectionItemFieldTranslationRequest> Translations { get; set; } = new();
    }

    public class SectionItemFieldTranslationRequest
    {
        public int LanguageId { get; set; }
        public string LanguageCode { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}

