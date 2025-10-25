using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Application.Dtos
{
    public class TemplateDto
    {
        public int Id { get; set; }
        public TemplateType TemplateType { get; set; }
        public string TemplateKey { get; set; } = string.Empty;
        public string? ConfigurationSchema { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public List<TemplateTranslationDto> Translations { get; set; } = new List<TemplateTranslationDto>();
    }

    public class TemplateTranslationDto
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class TemplateCreateDto
    {
        public TemplateType TemplateType { get; set; }
        public string TemplateKey { get; set; } = string.Empty;
        public string? ConfigurationSchema { get; set; }
        public bool IsActive { get; set; } = true;
        public int SortOrder { get; set; } = 0;
        public List<TemplateTranslationCreateDto> Translations { get; set; } = new List<TemplateTranslationCreateDto>();
    }

    public class TemplateTranslationCreateDto
    {
        public int LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class TemplateUpdateDto
    {
        public int Id { get; set; }
        public TemplateType TemplateType { get; set; }
        public string TemplateKey { get; set; } = string.Empty;
        public string? ConfigurationSchema { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public List<TemplateTranslationUpdateDto> Translations { get; set; } = new List<TemplateTranslationUpdateDto>();
    }

    public class TemplateTranslationUpdateDto
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
