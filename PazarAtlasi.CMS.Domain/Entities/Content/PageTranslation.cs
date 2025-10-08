using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class PageTranslation : Entity<int>
    {
        public int PageId { get; set; }

        public int LanguageId { get; set; }

        public string Value { get; set; }

        public virtual Page Page { get; set; }

        public virtual Language Language { get; set; }
    }
}
