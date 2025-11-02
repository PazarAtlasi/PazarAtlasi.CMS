using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class Content : Entity<int>
    {
        public EntityType RelatedDataEntityType { get; set; }

        public int RelatedDataEntityId { get; set; }

        public string? Description { get; set; }

        public string? MetaTitle { get; set; }

        public string? MetaDescription { get; set; }

        public string? MetaKeywords { get; set; }

        public string? SubDescription { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public virtual ICollection<Page> Pages { get; set; } = new List<Page>();

        public virtual ICollection<ContentSlugs> ContentSlugs { get; set; } = new List<ContentSlugs>();
    }
}
