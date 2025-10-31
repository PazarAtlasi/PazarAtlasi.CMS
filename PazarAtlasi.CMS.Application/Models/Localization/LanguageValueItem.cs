namespace PazarAtlasi.CMS.Application.Models.Localization
{
    public class LanguageValueItem
    {
        public int Id { get; set; }
        public string LangKey { get; set; } = string.Empty;
        public string LangVal { get; set; } = string.Empty;
        public string? LangDescription { get; set; }
        public string LangCode { get; set; } = string.Empty;
        public string? Category { get; set; }
        public bool IsActive { get; set; } = true;
    }
}