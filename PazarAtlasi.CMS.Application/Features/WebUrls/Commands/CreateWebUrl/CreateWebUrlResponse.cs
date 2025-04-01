namespace PazarAtlasi.CMS.Application.Features.WebUrls.Commands.CreateWebUrl
{
    public class CreateWebUrlResponse
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string TargetUrl { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}