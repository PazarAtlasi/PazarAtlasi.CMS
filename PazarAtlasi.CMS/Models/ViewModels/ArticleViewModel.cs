using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string? FeaturedImage { get; set; }
        public string? VideoUrl { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsTrending { get; set; }
        public int? ReadingTime { get; set; }
        public string? Tags { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }

        // Translations
        public List<ArticleTranslationViewModel> Translations { get; set; } = new();

        // Available data
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();
        public List<ArticleCategoryViewModel> AvailableCategories { get; set; } = new();
    }

    public class ArticleTranslationViewModel
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageCode { get; set; }
        public string? LanguageName { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Slug is required")]
        [StringLength(200)]
        public string Slug { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Summary { get; set; }
        
        public string? Content { get; set; }
        
        [StringLength(200)]
        public string? MetaTitle { get; set; }
    }

    public class ArticleCategoryViewModel
    {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? Icon { get; set; }
        public string? Color { get; set; }
        public int SortOrder { get; set; }
        public Status Status { get; set; }

        // Translations
        public List<ArticleCategoryTranslationViewModel> Translations { get; set; } = new();
        
        // For display
        public string? Name { get; set; }
    }

    public class ArticleCategoryTranslationViewModel
    {
        public int Id { get; set; }
        public int ArticleCategoryId { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageCode { get; set; }
        public string? LanguageName { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        [StringLength(100)]
        public string? Slug { get; set; }
    }
}
