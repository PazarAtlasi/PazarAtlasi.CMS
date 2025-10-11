using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class SectionItem : Entity<int>
    {
        public int SectionId { get; set; }

        public string? Code { get; set; }

        public SectionItemType Type { get; set; } = SectionItemType.None;

        public MediaType MediaType { get; set; } = MediaType.None;
        
        public string? PictureUrl { get; set; }

        public string? VideoUrl { get; set; }

        public string? RedirectUrl { get; set; }

        public string? Icon { get; set; }

        public int SortOrder { get; set; } = 0;

        public string? MediaAttributes { get; set; } // JSON field for additional media properties
        
        public virtual Section Section { get; set; }

        public virtual ICollection<SectionItemTranslation> Translations { get; set; }
    }
}
