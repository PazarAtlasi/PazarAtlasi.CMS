namespace PazarAtlasi.CMS.Application.Dtos
{
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
}
