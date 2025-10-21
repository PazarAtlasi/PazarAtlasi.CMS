using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class SectionItem : Entity<int>
    {
        public int SectionId { get; set; }

        public int? ParentSectionItemId { get; set; }

        /// <summary>
        /// Configuration template used to create this item
        /// Defines field structure, validation rules, UI behavior, etc.
        /// </summary>
        public int SectionItemSettingId { get; set; }

        public SectionItemType Type { get; set; } = SectionItemType.None;

        public MediaType MediaType { get; set; }
        
        public int? LinkedPageId { get; set; } // Reference to linked page

        public int SortOrder { get; set; } = 0;

        // Navigation properties
        public virtual Section Section { get; set; }

        public virtual SectionItem? ParentSectionItem { get; set; }

        /// <summary>
        /// Configuration template that defines this item's structure
        /// </summary>
        public virtual SectionItemSetting Setting { get; set; } = null!;

        public virtual ICollection<SectionItemField> Fields { get; set; } = new List<SectionItemField>();

        public virtual ICollection<SectionItemTranslation> Translations { get; set; } = new List<SectionItemTranslation>();
    }
}
