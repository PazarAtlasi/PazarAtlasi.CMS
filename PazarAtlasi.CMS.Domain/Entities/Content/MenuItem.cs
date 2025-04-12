using System;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class MenuItem : BaseEntity
    {
        public string WebUrlId { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public int DisplayOrder { get; set; }
        public string? Url { get; set; }
        public bool ShowStatus { get; set; }
        public string? Status { get; set; }
        public string? TranslationKey { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Navigation properties
        public MenuItem? Parent { get; set; }
        public ICollection<MenuItem> Children { get; set; } = new List<MenuItem>();
        public ICollection<MenuContent> MenuContents { get; set; } = new List<MenuContent>();
        public ICollection<MenuItemIcon> MenuItemIcons { get; set; } = new List<MenuItemIcon>();
        public ICollection<MenuPermission> MenuPermissions { get; set; } = new List<MenuPermission>();
        
        private MenuItem() { } // For EF Core

        public MenuItem(string webUrlId, string label, string type, int displayOrder, string? translationKey = null)
        {
            WebUrlId = webUrlId;
            Label = label;
            Type = type;
            DisplayOrder = displayOrder;
            TranslationKey = translationKey;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            Children = new List<MenuItem>();
            MenuItemIcons = new List<MenuItemIcon>();
        }

        public void SetUrl(string url)
        {
            Url = url;
        }

        public void SetParent(MenuItem? parent)
        {
            ParentId = parent?.Id;
            Parent = parent;
        }

        public void SetStatus(bool showStatus, string? status = null)
        {
            ShowStatus = showStatus;
            Status = status;
        }

        public void Activate()
        {
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
} 