namespace PazarAtlasi.CMS.Application.Features.Campaigns.Queries;

public class CampaignDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public string? TargetUrl { get; set; }
} 