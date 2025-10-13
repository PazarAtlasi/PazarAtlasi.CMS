using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Application.Dtos
{
    public class MediaUploadResultDto
    {
        public bool Success { get; set; }
        public string? Url { get; set; }
        public string? FileName { get; set; }
        public string? Message { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
