using System;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class MenuItemIcon : BaseEntity
    {
        public int MenuItemId { get; set; }
        public int IconId { get; set; }
        public string IconPosition { get; set; } = "left";
        
        // Navigation properties
        public MenuItem MenuItem { get; set; }
        public Icon Icon { get; set; }
    }
} 