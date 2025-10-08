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
        public Content(string description)
        {
            Description = description;
        }

        public Content()
        {
        }

        public EntityType RelatedEntityId { get; set; }

        public int RelatedDataId { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Page> Pages { get; set; }
    }
}
