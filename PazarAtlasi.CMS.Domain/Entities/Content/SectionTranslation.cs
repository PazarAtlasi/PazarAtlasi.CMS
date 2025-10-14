using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class SectionTranslation : Entity<int>
    {
        public int SectionId { get; set; }

        public int LanguageId { get; set; }

        public string Name { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public virtual Section Section { get; set; }

        public virtual Language Language { get; set; }
    }
}
