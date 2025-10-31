using PazarAtlasi.CMS.Domain.Common;
using PazarAtlasi.CMS.Domain.Entities.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Common
{
    public class Language : Entity<int>
    {
        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string? NativeName { get; set; }

        public string? Flag { get; set; }

        public bool IsDefault { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public int SortOrder { get; set; } = 0;

        // Navigation Properties
        public virtual ICollection<LocalizationValue> LocalizationValues { get; set; } = new List<LocalizationValue>();
    }
}
