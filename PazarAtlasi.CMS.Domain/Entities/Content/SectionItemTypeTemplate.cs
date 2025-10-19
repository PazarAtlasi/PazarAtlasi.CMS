using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class SectionItemTypeTemplate : Entity<int>
    {
        public SectionItemType SectionItemType { get; set; }

        public int TemplateId { get; set; }

        public string? CustomConfiguration { get; set; } // JSON configuration specific to this section-template combination

        public virtual Template Template { get; set; } = null!;
    }
}
