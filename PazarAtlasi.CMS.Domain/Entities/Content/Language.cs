using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class Language : Entity<int>
    {
        public required string Name { get; set; }

        public string? Code { get; set; }

        public bool IsDefault { get; set; }
    }
}
