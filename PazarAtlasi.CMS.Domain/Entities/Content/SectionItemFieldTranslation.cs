using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class SectionItemFieldTranslation : Entity<int>
    {
        public SectionItemFieldTranslation() { }

        public int SectionItemFieldId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }

        // Navigation property
        public virtual SectionItemField SectionItemField { get; set; }

    }
}
