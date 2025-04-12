using MediatR;
using System;

namespace PazarAtlasi.CMS.Application.Features.MenuItems.Commands.CreateMenuItem
{
    public class CreateMenuItemCommand : IRequest<CreateMenuItemResponse>
    {
        public string WebUrlId { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public int? ParentId { get; set; }
        public int DisplayOrder { get; set; }
        public string Url { get; set; }
        public bool ShowStatus { get; set; }
        public string Status { get; set; }
        public string TranslationKey { get; set; }
        public bool IsActive { get; set; } = true;
    }
} 