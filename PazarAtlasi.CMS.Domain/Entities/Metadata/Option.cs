using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    /// <summary>
    /// Represents product options like Color, Size, Material, etc.
    /// </summary>
    public class Option : Entity<int>
    {
        public int? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string IntegrationCode { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public OptionType Type { get; set; } = OptionType.Text;
        public string? DefaultValue { get; set; }
        public bool IsRequired { get; set; } = false;
        public bool AllowMultipleSelection { get; set; } = false;
        public int SortOrder { get; set; } = 0;

        // Navigation Properties
        [ForeignKey("ParentId")]
        public virtual Option? ParentOption { get; set; }
        
        public virtual ICollection<Option> ChildOptions { get; set; } = new List<Option>();
        public virtual ICollection<OptionTranslation> Translations { get; set; } = new List<OptionTranslation>();
        public virtual ICollection<ProductOption> ProductOptions { get; set; } = new List<ProductOption>();
    }
}