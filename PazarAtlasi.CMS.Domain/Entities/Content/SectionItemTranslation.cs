using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class SectionItemTranslation : Entity<int>
    {
        public int SectionItemId { get; set; }

        public int LanguageId { get; set; }

        public string Name { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public virtual SectionItem SectionItem { get; set; }
        
        public virtual Language Language { get; set; }
    }
}
