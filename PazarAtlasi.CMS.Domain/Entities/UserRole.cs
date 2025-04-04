using System;

namespace PazarAtlasi.CMS.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string AssignedBy { get; set; }
        
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
} 