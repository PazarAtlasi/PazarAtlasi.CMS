namespace PazarAtlasi.CMS.Application.Features.WebUrls.Commands.DeleteWebUrl;

public class DeleteWebUrlResponse
{
    public int Id { get; set; }
    public bool IsSuccess { get; set; }
    public required string Message { get; set; }
}