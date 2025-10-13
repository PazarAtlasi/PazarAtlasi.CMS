using Microsoft.AspNetCore.Http;
using PazarAtlasi.CMS.Application.Dtos;

namespace PazarAtlasi.CMS.Application.Interfaces.Infrastructure
{
    public interface IMediaUploadService
    {
        /// <summary>
        /// Uploads an image file and returns the URL
        /// </summary>
        Task<MediaUploadResultDto> UploadImageAsync(IFormFile file, string? folder = null);

        /// <summary>
        /// Uploads a video file and returns the URL
        /// </summary>
        Task<MediaUploadResultDto> UploadVideoAsync(IFormFile file, string? folder = null);

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
}

