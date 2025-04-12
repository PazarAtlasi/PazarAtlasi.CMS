using System.Collections.Generic;

namespace PazarAtlasi.CMS.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        
        public ICollection<BlogTag> BlogTags { get; set; }
        
        public Tag()
        {
            BlogTags = new HashSet<BlogTag>();
        }
    }
} 