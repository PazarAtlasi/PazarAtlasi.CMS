using System;

namespace PazarAtlasi.CMS.Domain.Entities.Content
{
    public class MenuPermission : BaseEntity
    {
        public int MenuItemId { get; set; }
        public string RoleId { get; set; }
        public bool HasAccess { get; set; } = true;
        
        // Navigation properties
        public MenuItem MenuItem { get; set; }
    }
} 