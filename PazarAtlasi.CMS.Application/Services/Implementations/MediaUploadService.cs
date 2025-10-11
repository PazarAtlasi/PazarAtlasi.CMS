using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PazarAtlasi.CMS.Application.Services.Abstractions;

namespace PazarAtlasi.CMS.Application.Services.Implementations
{
    public class MediaUploadService : IMediaUploadService
    {
        private readonly IHostingEnvironment _environment;
        private readonly string[] _allowedImageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp", ".svg" };
        private readonly string[] _allowedVideoExtensions = { ".mp4", ".webm", ".ogg", ".mov", ".avi" };
        private readonly long _maxImageSize = 5 * 1024 * 1024; // 5MB
        private readonly long _maxVideoSize = 50 * 1024 * 1024; // 50MB

        public MediaUploadService(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<MediaUploadResult> UploadImageAsync(IFormFile file, string? folder = null)
        {
            var result = new MediaUploadResult();

            try
            {
                if (file == null || file.Length == 0)
                {
                    result.Success = false;
                    result.Message = "No file provided";
                    result.Errors.Add("EMPTY_FILE");
                    return result;
                }

                if (!IsValidImage(file))
                {
                    result.Success = false;
                    result.Message = "Invalid image format";
                    result.Errors.Add("INVALID_FORMAT");
                    return result;
                }

                if (file.Length > _maxImageSize)
                {
                    result.Success = false;
                    result.Message = $"Image size must be less than {_maxImageSize / 1024 / 1024}MB";
                    result.Errors.Add("FILE_TOO_LARGE");
                    return result;
                }

                var uploadFolder = Path.Combine(_environment.WebRootPath, "uploads", "images", folder ?? "general");
                
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var relativeUrl = $"/uploads/images/{folder ?? "general"}/{fileName}";

                result.Success = true;
                result.Url = relativeUrl;
                result.FileName = fileName;
                result.Message = "Image uploaded successfully";

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "An error occurred while uploading image";
                result.Errors.Add(ex.Message);
                return result;
            }
        }

        public async Task<MediaUploadResult> UploadVideoAsync(IFormFile file, string? folder = null)
        {
            var result = new MediaUploadResult();

            try
            {
                if (file == null || file.Length == 0)
                {
                    result.Success = false;
                    result.Message = "No file provided";
                    result.Errors.Add("EMPTY_FILE");
                    return result;
                }

                if (!IsValidVideo(file))
                {
                    result.Success = false;
                    result.Message = "Invalid video format";
                    result.Errors.Add("INVALID_FORMAT");
                    return result;
                }

                if (file.Length > _maxVideoSize)
                {
                    result.Success = false;
                    result.Message = $"Video size must be less than {_maxVideoSize / 1024 / 1024}MB";
                    result.Errors.Add("FILE_TOO_LARGE");
                    return result;
                }

                var uploadFolder = Path.Combine(_environment.WebRootPath, "uploads", "videos", folder ?? "general");
                
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var relativeUrl = $"/uploads/videos/{folder ?? "general"}/{fileName}";

                result.Success = true;
                result.Url = relativeUrl;
                result.FileName = fileName;
                result.Message = "Video uploaded successfully";

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "An error occurred while uploading video";
                result.Errors.Add(ex.Message);
                return result;
            }
        }

        public async Task<bool> DeleteMediaAsync(string url)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url))
                    return false;

                var filePath = Path.Combine(_environment.WebRootPath, url.TrimStart('/').Replace("/", "\\"));
                
                if (File.Exists(filePath))
                {
                    await Task.Run(() => File.Delete(filePath));
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidImage(IFormFile file)
        {
            if (file == null)
                return false;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return _allowedImageExtensions.Contains(extension);
        }

        public bool IsValidVideo(IFormFile file)
        {
            if (file == null)
                return false;

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            return _allowedVideoExtensions.Contains(extension);
        }
    }
}

