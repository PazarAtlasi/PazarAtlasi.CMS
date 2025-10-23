namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class SectionTranslationRequest
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string LanguageCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
