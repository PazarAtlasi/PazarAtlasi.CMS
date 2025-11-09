using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Identity
{
    public class User : Entity<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string? PhoneNumber { get; set; }

        public short? Gender { get; set; }

        public string? MotherName { get; set; }

        public string FatherName { get; set; }

        public int? DepartmentId { get; set; }

        public int? BranchId { get; set; }

        // Navigation Properties
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
