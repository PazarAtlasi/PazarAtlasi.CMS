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
        public SectionType Type { get; set; } = SectionType.None;

        public string? Attributes { get; set; }

        public int SortOrder { get; set; } = 0;

        public string? Configure { get; set; }

        public virtual ICollection<SectionItemFieldValue> SectionItemFieldValues { get; set; } = new List<SectionItemFieldValue>();

        public virtual ICollection<SectionItemValue> SectionItemValues { get; set; } = new List<SectionItemValue>();

        public virtual ICollection<SectionTranslation> Translations { get; set; } = new List<SectionTranslation>();
        
        public virtual ICollection<SectionTypeTemplate> SectionTemplates { get; set; } = new List<SectionTypeTemplate>();
    }
}
