using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Localization
{
    public class LocalizationValue : Entity<int>
    {
        public int LanguageId { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Category { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public virtual Language Language { get; set; } = null!;
    }
}