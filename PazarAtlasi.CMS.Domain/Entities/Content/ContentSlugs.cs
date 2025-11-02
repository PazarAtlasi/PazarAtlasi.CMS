using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class ContentSlugs : Entity<int>
    { 
        public int ContentId { get; set; }

        public required string Slug { get; set; }

        public int LanguageId { get; set; }

        public int? Priority { get; set; }

        public bool IsCanonical { get; set; }

        public virtual Content Content { get; set; } = null!;

        public virtual Language Language { get; set; } = null!;
    }
}
