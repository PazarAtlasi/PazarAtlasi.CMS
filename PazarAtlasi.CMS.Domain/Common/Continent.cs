using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Domain.Common
{
    public class Continent : Entity<int>
    {
        public required string Name { get; set; }

        public string? Code { get; set; }

        public bool IsActive { get; set; } = true;

        public int SortOrder { get; set; } = 0;

        // Navigation Properties
        public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
    }
}