using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class SectionItemTranslation : Entity<int>
    {
        public int SectionItemId { get; set; }
        public int LanguageId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public virtual SectionItem SectionItem { get; set; } = null!;
        public virtual Language Language { get; set; } = null!;
    }
}