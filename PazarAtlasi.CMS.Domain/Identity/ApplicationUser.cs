using Microsoft.AspNetCore.Identity;

namespace PazarAtlasi.CMS.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}".Trim();
    }
} 