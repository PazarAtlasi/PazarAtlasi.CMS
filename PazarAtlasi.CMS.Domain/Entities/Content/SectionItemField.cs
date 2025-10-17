using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class SectionItemField : Entity<int> 
    {
        public int SectionItemId { get; set; }

        public SectionItemFieldType FieldType { get; set; }

        public string FieldKey { get; set; } = string.Empty;

        public string FieldValue { get; set; } = string.Empty;
        
        // Navigation property
        public virtual SectionItem SectionItem { get; set; }

        public virtual ICollection<SectionItemFieldTranslation> Translations { get; set; } = new List<SectionItemFieldTranslation>();
    }
}
