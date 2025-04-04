using System;

namespace PazarAtlasi.CMS.Domain.Entities
{
    public class RolePermission : BaseEntity
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string AssignedBy { get; set; }

        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }
    }
} 