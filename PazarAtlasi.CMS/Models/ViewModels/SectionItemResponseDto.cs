using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class SectionItemResponseDto
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public SectionItemType Type { get; set; }
        public MediaType MediaType { get; set; }
        public string? PictureUrl { get; set; }
        public string? VideoUrl { get; set; }
        public string? RedirectUrl { get; set; }
        public string? Icon { get; set; }
        public int SortOrder { get; set; }
        public string? MediaAttributes { get; set; }
        public Status Status { get; set; }
        public List<SectionItemTranslationResponseDto> Translations { get; set; } = new();
    }

    public class SectionItemTranslationResponseDto
    {
        public int Id { get; set; }
        public int SectionItemId { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
    }

    public class SectionItemSaveResponseDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
