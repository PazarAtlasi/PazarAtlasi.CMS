using System;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Application.Features.MenuItems.Queries.GetAllMenuItems
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string WebUrlId { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public int? ParentId { get; set; }
        public int DisplayOrder { get; set; }
        public string Url { get; set; }
        public bool ShowStatus { get; set; }
        public string Status { get; set; }
        public string TranslationKey { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        
        // Navigation properties as DTOs
        public MenuItemDto Parent { get; set; }
        public List<MenuItemDto> Children { get; set; }
        public List<MenuItemIconDto> Icons { get; set; }
    }

    public class MenuItemIconDto
    {
        public int Id { get; set; }
        public string IconName { get; set; }
        public string IconType { get; set; }
        public string IconPosition { get; set; }
    }
} 