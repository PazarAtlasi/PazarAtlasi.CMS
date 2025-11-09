using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Identity
{
    public class RoleOperationalClaim : Entity<int>
    {
        public int RoleId { get; set; }

        public int OperationalClaimId { get; set; }

        // Navigation properties
        public virtual Role Role { get; set; }

        public virtual OperationalClaim OperationalClaim { get; set; }
    }
}
