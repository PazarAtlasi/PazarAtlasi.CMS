using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// Slug listesi için view model
    /// </summary>
    public class SlugManagementListViewModel
    {
        public int Id { get; set; }
        public string Slug { get; set; } = string.Empty;
        public int ContentId { get; set; }
        public string? ContentTitle { get; set; }
        public EntityType EntityType { get; set; }
        public string EntityTypeName { get; set; } = string.Empty;
        public int EntityId { get; set; }
        public string? EntityName { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public bool IsCanonical { get; set; }
        public int? Priority { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Slug listesi response
    /// </summary>
    public class SlugManagementListResponse
    {
        public List<SlugManagementListViewModel> Slugs { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchTerm { get; set; }
        public EntityType? EntityTypeFilter { get; set; }
        public int? LanguageFilter { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }

    /// <summary>
    /// Slug ekleme/düzenleme view model
    /// </summary>
    public class SlugEditViewModel
    {
        public int Id { get; set; }
        
        public int ContentId { get; set; }
        
        [Required(ErrorMessage = "Slug alanı zorunludur")]
        [StringLength(500, ErrorMessage = "Slug en fazla 500 karakter olabilir")]
        [RegularExpression(@"^[a-z0-9\-\/]+$", ErrorMessage = "Slug sadece küçük harf, rakam, tire ve slash içerebilir")]
        public string Slug { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Dil seçimi zorunludur")]
        public int LanguageId { get; set; }
        
        public int? Priority { get; set; }
        
        public bool IsCanonical { get; set; }
        
        // Entity bilgileri
        public EntityType EntityType { get; set; }
        public int EntityId { get; set; }
        public string? EntityName { get; set; }
        
        // Available data
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();
    }

    /// <summary>
    /// Yeni Content ve Slug oluşturma
    /// </summary>
    public class CreateContentSlugViewModel
    {
        [Required(ErrorMessage = "Entity tipi seçimi zorunludur")]
        public EntityType EntityType { get; set; }
        
        [Required(ErrorMessage = "Entity seçimi zorunludur")]
        public int EntityId { get; set; }
        
        [Required(ErrorMessage = "Slug alanı zorunludur")]
        [StringLength(500, ErrorMessage = "Slug en fazla 500 karakter olabilir")]
        [RegularExpression(@"^[a-z0-9\-\/]+$", ErrorMessage = "Slug sadece küçük harf, rakam, tire ve slash içerebilir")]
        public string Slug { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Dil seçimi zorunludur")]
        public int LanguageId { get; set; }
        
        public bool IsCanonical { get; set; } = true;
        
        public int Priority { get; set; } = 1;
        
        // SEO bilgileri (opsiyonel)
        public string? Title { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        
        // Available data
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();
        public Dictionary<EntityType, List<EntitySelectItem>> AvailableEntities { get; set; } = new();
    }

    /// <summary>
    /// Entity seçim item'ı
    /// </summary>
    public class EntitySelectItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; }
    }
}
