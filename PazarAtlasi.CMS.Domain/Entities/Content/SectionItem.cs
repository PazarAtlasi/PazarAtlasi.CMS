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
        public int? ParentSectionItemId { get; set; }

        /// <summary>
        /// Template used to create this item (optional)
        /// </summary>
        public int? TemplateId { get; set; }

        public SectionItemType Type { get; set; } = SectionItemType.None;

        public MediaType MediaType { get; set; }
        
        public int SortOrder { get; set; } = 0;

        /// <summary>
        /// Display title for this item (from template or custom)
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Description for this item (from template or custom)
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Whether this item can be reordered
        /// </summary>
        public bool AllowReorder { get; set; } = true;

        /// <summary>
        /// Whether this item can be removed dynamically
        /// </summary>
        public bool AllowRemove { get; set; } = true;

        /// <summary>
        /// Icon class for UI display
        /// </summary>
        public string? IconClass { get; set; }

        public virtual SectionItem? ParentSectionItem { get; set; }

        public virtual Template? Template { get; set; }

        public virtual ICollection<SectionItemField> SectionItemFields { get; set; } = new List<SectionItemField>();

        public virtual ICollection<SectionItemFieldValue> SectionItemFieldValues { get; set; } = new List<SectionItemFieldValue>();

        public virtual ICollection<SectionItemTranslation> Translations { get; set; } = new List<SectionItemTranslation>();
    }
}
