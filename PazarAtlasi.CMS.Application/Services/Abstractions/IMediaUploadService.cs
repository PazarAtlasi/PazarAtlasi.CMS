using Microsoft.AspNetCore.Http;

namespace PazarAtlasi.CMS.Application.Services.Abstractions
{
    public interface IMediaUploadService
    {
        /// <summary>
        /// Uploads an image file and returns the URL
        /// </summary>
        Task<MediaUploadResult> UploadImageAsync(IFormFile file, string? folder = null);

        /// <summary>
        /// Uploads a video file and returns the URL
        /// </summary>
        Task<MediaUploadResult> UploadVideoAsync(IFormFile file, string? folder = null);

        /// <summary>
        /// Deletes a media file by URL
        /// </summary>
        Task<bool> DeleteMediaAsync(string url);

        /// <summary>
        /// Validates if file is an allowed image format
        /// </summary>
        bool IsValidImage(IFormFile file);

        /// <summary>
        /// Validates if file is an allowed video format
        /// </summary>
        bool IsValidVideo(IFormFile file);
    }

    public class MediaUploadResult
    {
        public bool Success { get; set; }
        public string? Url { get; set; }
        public string? FileName { get; set; }
        public string? Message { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}

