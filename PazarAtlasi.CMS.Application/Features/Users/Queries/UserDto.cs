using System;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Application.Features.Users.Queries
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<string> Roles { get; set; }
    }
} 