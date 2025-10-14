using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class Section : Entity<int>
    {
        public int PageId { get; set; }

        public SectionType Type { get; set; } = SectionType.None;

        public SectionTemplateType SectionTemplateType { get; set; }

        public string? Attributes { get; set; }

        public int SortOrder { get; set; } = 0;

        public string? Configure { get; set; }

        public virtual Page Page { get; set; }

        public virtual ICollection<SectionItem> SectionItems { get; set; }

        public virtual ICollection<SectionTranslation> Translations { get; set; }   
    }
}
