using PazarAtlasi.CMS.Domain.Common;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    /// <summary>
    /// ViewModel for Template Create form
    /// </summary>
    public class TemplateCreateViewModel
    {
        public string TemplateKey { get; set; } = string.Empty;
        public string? ConfigurationSchema { get; set; }
        public bool IsActive { get; set; } = true;
        public int SortOrder { get; set; } = 0;
        
        /// <summary>
        /// Available languages for translations
        /// </summary>
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new List<LanguageViewModel>();
        
        /// <summary>
        /// Template translations for each language
        /// </summary>
        public List<TemplateTranslationCreateViewModel> Translations { get; set; } = new List<TemplateTranslationCreateViewModel>();
    }

    /// <summary>
    /// ViewModel for Template Edit form
    /// </summary>
    public class TemplateEditViewModel
    {
        public int Id { get; set; }

        public string TemplateKey { get; set; } = string.Empty;

        public string? ConfigurationSchema { get; set; }

        public bool IsActive { get; set; }

        public int SortOrder { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        
        /// <summary>
        /// Available languages for translations
        /// </summary>
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new List<LanguageViewModel>();
        
        /// <summary>
        /// Template translations for each language
        /// </summary>
        public List<TemplateTranslationEditViewModel> Translations { get; set; } = new List<TemplateTranslationEditViewModel>();
    }

    /// <summary>
    /// ViewModel for Template List
    /// </summary>
    public class TemplateListViewModel
    {
        public int Id { get; set; }

        public string TemplateKey { get; set; } = string.Empty;

        public string? ConfigurationSchema { get; set; }

        public bool IsActive { get; set; }

        public int SortOrder { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        
        /// <summary>
        /// Template name from default language translation
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Template description from default language translation
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Number of translations available
        /// </summary>
        public int TranslationCount { get; set; }
        
        /// <summary>
        /// Status badge CSS class
        /// </summary>
        public string StatusBadgeClass => IsActive ? "bg-green-100 text-green-800" : "bg-red-100 text-red-800";
        
        /// <summary>
        /// Status display name
        /// </summary>
        public string StatusName => IsActive ? "Active" : "Inactive";
    }

    /// <summary>
    /// ViewModel for Template Translation Create
    /// </summary>
    public class TemplateTranslationCreateViewModel
    {
        public int LanguageId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        
        /// <summary>
        /// Language information for display
        /// </summary>
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public bool IsDefault { get; set; }
    }

    /// <summary>
    /// ViewModel for Template Translation Edit
    /// </summary>
    public class TemplateTranslationEditViewModel
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        
        /// <summary>
        /// Language information for display
        /// </summary>
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public bool IsDefault { get; set; }
    }

    /// <summary>
    /// Response model for Template List with pagination
    /// </summary>
    public class TemplateListResponse
    {
        public List<TemplateListViewModel> Templates { get; set; } = new List<TemplateListViewModel>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }

    /// <summary>
    /// ViewModel for Template Details
    /// </summary>
    public class TemplateDetailsViewModel
    {
        public int Id { get; set; }
        public string TemplateKey { get; set; } = string.Empty;
        public string? ConfigurationSchema { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary>
        /// Template translations
        /// </summary>
        public List<TemplateTranslationViewModel> Translations { get; set; } = new List<TemplateTranslationViewModel>();
        
        /// <summary>
        /// Section types that use this template
        /// </summary>
        public List<SectionTypeUsageViewModel> SectionTypeUsages { get; set; } = new List<SectionTypeUsageViewModel>();
        
        /// <summary>
        /// Template name from default language
        /// </summary>
        public string Name => Translations.FirstOrDefault(t => t.IsDefault)?.Name ?? "Unnamed Template";
        
        /// <summary>
        /// Template description from default language
        /// </summary>
        public string? Description => Translations.FirstOrDefault(t => t.IsDefault)?.Description;
    }

    /// <summary>
    /// ViewModel for Template Translation display
    /// </summary>
    public class TemplateTranslationViewModel
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        
        /// <summary>
        /// Language information
        /// </summary>
        public string LanguageName { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
    }

    /// <summary>
    /// ViewModel for Section Type usage information
    /// </summary>
    public class SectionTypeUsageViewModel
    {
        public SectionType SectionType { get; set; }
        public string SectionTypeName => SectionType.ToString();
        public int UsageCount { get; set; }
        public string? CustomConfiguration { get; set; }
    }
}