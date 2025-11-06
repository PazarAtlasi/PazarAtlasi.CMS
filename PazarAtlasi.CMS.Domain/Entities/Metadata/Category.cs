using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PazarAtlasi.CMS.Domain.Entities.Metadata
{
    public class Category : Entity<int>
    {
        public int? ParentCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? IntegrationCode { get; set; }
        public int SortOrder { get; set; } = 0;

        // Navigation Properties
        [ForeignKey("ParentCategoryId")]
        public virtual Category? ParentCategory { get; set; }
        
        public virtual ICollection<Category> ChildCategories { get; set; } = new List<Category>();
        public virtual ICollection<CategoryTranslation> Translations { get; set; } = new List<CategoryTranslation>();
        public virtual ICollection<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
    }
}
