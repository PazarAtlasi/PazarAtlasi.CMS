using System;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class MenuContent : BaseEntity
    {
        public int MenuItemId { get; set; }
        public string ContentJson { get; set; }
        
        // Navigation properties
        public MenuItem MenuItem { get; set; }
    }
} 