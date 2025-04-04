using System.ComponentModel.DataAnnotations;

namespace PazarAtlasi.CMS.Domain.Entities;

public class Campaign : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string ImageUrl { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public bool IsActive { get; set; }

    public string? TargetUrl { get; set; }
} 