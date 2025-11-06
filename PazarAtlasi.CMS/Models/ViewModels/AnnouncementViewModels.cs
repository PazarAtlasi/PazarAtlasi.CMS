using PazarAtlasi.CMS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Models.ViewModels
{
    public class AnnouncementListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Summary { get; set; }
        public DateTime PublishStart { get; set; }
        public DateTime PublishEnd { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedByName { get; set; }
        public string StatusColor { get; set; } = string.Empty;
        public string StatusText { get; set; } = string.Empty;
    }

    public class AnnouncementListResponse
    {
        public List<AnnouncementListViewModel> Announcements { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public string? StatusFilter { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }

    public class AnnouncementCreateViewModel
    {
        public string? CoverImage { get; set; }

        [Required(ErrorMessage = "Yayın başlangıç tarihi zorunludur.")]
        public DateTime PublishStart { get; set; }

        [Required(ErrorMessage = "Yayın bitiş tarihi zorunludur.")]
        public DateTime PublishEnd { get; set; }

        public Status Status { get; set; }

        // Çok dilli içerik
        public List<AnnouncementTranslationViewModel> Translations { get; set; } = new();

        // Available languages
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();
    }

    public class AnnouncementEditViewModel
    {
        public int Id { get; set; }

        public string? CoverImage { get; set; }

        [Required(ErrorMessage = "Yayın başlangıç tarihi zorunludur.")]
        public DateTime PublishStart { get; set; }

        [Required(ErrorMessage = "Yayın bitiş tarihi zorunludur.")]
        public DateTime PublishEnd { get; set; }

        public Status Status { get; set; }

        // Çok dilli içerik
        public List<AnnouncementTranslationViewModel> Translations { get; set; } = new();

        // Available languages
        public List<LanguageViewModel> AvailableLanguages { get; set; } = new();
    }

    public class AnnouncementTranslationViewModel
    {
        public int Id { get; set; }
        public int AnnouncementId { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public bool IsDefault { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(500, ErrorMessage = "Başlık en fazla 500 karakter olabilir.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "İçerik alanı zorunludur.")]
        public string Content { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Özet en fazla 1000 karakter olabilir.")]
        public string? Summary { get; set; }
    }

    public class LanguageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }

    public class LanguageListViewModel
    {
        public List<LanguageViewModel> Languages { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}