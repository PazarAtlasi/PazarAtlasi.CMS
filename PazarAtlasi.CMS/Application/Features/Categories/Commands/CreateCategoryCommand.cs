using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand
    {
        [Required(ErrorMessage = "Kategori adı zorunludur")]
        [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
        public string Description { get; set; }

        public int? ParentId { get; set; }

        [Required(ErrorMessage = "Sıralama değeri zorunludur")]
        [Range(0, int.MaxValue, ErrorMessage = "Sıralama değeri 0 veya daha büyük olmalıdır")]
        public int DisplayOrder { get; set; }

        public string ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;
    }
} 