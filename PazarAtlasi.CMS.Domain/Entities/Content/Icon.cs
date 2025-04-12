using System;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class Icon : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string SvgContent { get; set; }
        
        // Navigation properties
        public ICollection<MenuItemIcon> MenuItemIcons { get; set; }
    }
} 