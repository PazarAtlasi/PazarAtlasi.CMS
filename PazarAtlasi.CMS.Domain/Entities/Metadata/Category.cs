using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    public class Category : Entity<int>
    {
        public int? ParentId { get; set; }

        public string Code { get; set; }

        public string IntegrationCode { get; set; }

        public int SortOrder { get; set; } = 0;
    }
}
