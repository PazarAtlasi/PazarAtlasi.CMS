using PazarAtlasi.CMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Domain.Entities.Identity
{
    public class UserLogin : Entity<int>
    {
        public int UserId { get; set; }

        public DateTime? LogoutTime { get; set; }

        public string? IpAddress { get; set; }

        public string? UserAgent { get; set; }

        public bool IsSuccessful { get; set; }

        public string? FailureReason { get; set; }

        public string? SessionId { get; set; }

        public string? DeviceInfo { get; set; }

        public string? Location { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
