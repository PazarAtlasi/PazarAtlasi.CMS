using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Identity
{
    public class OperationalClaim : Entity<int>
    {
        public string Name { get; set; }

        public string? DisplayName { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<RoleOperationalClaim> RoleOperationalClaims { get; set; }
    }
}
