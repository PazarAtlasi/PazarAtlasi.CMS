namespace PazarAtlasi.CMS.Application.Features.WebUrls.Commands.UpdateWebUrl;

public class UpdateWebUrlResponse
{
    public int Id { get; set; }
    public required string Slug { get; set; }
    public required string TargetUrl { get; set; }
    public bool IsSuccess { get; set; }
    public required string Message { get; set; }
}