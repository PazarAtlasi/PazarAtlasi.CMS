using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    public class CategoryTranslation : Entity<int>
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public int LanguageId { get; set; }

        public virtual Category Category { get; set; }
        
        public virtual Language Language { get; set; }
    }
}
