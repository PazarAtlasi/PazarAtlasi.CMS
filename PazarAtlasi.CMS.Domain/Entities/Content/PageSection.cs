using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class PageSection : Entity<int>
    {
        public int PageId { get; set; }
        
        public int SectionId { get; set; }

        public int SortOrder { get; set; } = 0;
        // Navigation properties
        
        public virtual Page Page { get; set; }
        
        public virtual Section Section { get; set; }
    }
}
