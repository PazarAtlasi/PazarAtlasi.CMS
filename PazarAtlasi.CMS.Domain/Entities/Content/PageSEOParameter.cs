using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class PageSEOParameter : Entity<int> 
    {
        public int PageId { get; set; }

        public string? MetaTitle { get; set; }

        public string? MetaDescription { get; set; }

        public string? MetaKeywords { get; set; }

        public string? SubDescription { get; set; }

        public string? Title { get; set; }

        public string? CanonicalURL { get; set; }

        public string? Author { get; set; }

        public string? Description { get; set; }

        public virtual Page Page { get; set; }  
    }
}
