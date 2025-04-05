using Microsoft.AspNetCore.Identity;

namespace PazarAtlasi.CMS.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string CompanyName { get; set; }
    }
} 