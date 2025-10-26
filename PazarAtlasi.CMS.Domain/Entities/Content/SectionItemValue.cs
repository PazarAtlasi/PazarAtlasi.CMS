using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class SectionItemValue : Entity<int>
    {
        public int SectionId { get; set; }
        
        public int SectionItemId { get; set; }

        public virtual Section Section { get; set; } = null!;
        
        public virtual SectionItem SectionItem { get; set; } = null!;
    }
}