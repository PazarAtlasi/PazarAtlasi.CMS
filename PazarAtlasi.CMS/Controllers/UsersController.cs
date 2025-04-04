using Microsoft.AspNetCore.Mvc;
using PazarAtlasi.CMS.Application.Features.Users.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            var users = new List<UserDto>
            {
                new UserDto
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "+90 555 123 4567",
                    Username = "johndoe",
                    IsActive = true,
                    LastLoginDate = System.DateTime.Now.AddDays(-1),
                    ProfilePictureUrl = "https://via.placeholder.com/150",
                    Address = "123 Main St, City",
                    DateOfBirth = new System.DateTime(1990, 1, 1),
                    Roles = new List<string> { "Admin", "Editor" }
                },
                new UserDto
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "+90 555 987 6543",
                    Username = "janesmith",
                    IsActive = true,
                    LastLoginDate = System.DateTime.Now.AddHours(-5),
                    ProfilePictureUrl = "https://via.placeholder.com/150",
                    Address = "456 Oak St, Town",
                    DateOfBirth = new System.DateTime(1992, 5, 15),
                    Roles = new List<string> { "Editor" }
                },
                new UserDto
                {
                    Id = 3,
                    FirstName = "Mike",
                    LastName = "Johnson",
                    Email = "mike.johnson@example.com",
                    PhoneNumber = "+90 555 456 7890",
                    Username = "mikej",
                    IsActive = false,
                    LastLoginDate = System.DateTime.Now.AddDays(-7),
                    ProfilePictureUrl = "https://via.placeholder.com/150",
                    Address = "789 Pine St, Village",
                    DateOfBirth = new System.DateTime(1988, 8, 20),
                    Roles = new List<string> { "Viewer" }
                }
            };

            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            // For now, return the same test data
            var user = new UserDto
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "+90 555 123 4567",
                Username = "johndoe",
                IsActive = true,
                LastLoginDate = System.DateTime.Now.AddDays(-1),
                ProfilePictureUrl = "https://via.placeholder.com/150",
                Address = "123 Main St, City",
                DateOfBirth = new System.DateTime(1990, 1, 1),
                Roles = new List<string> { "Admin", "Editor" }
            };

            return View(user);
        }
    }
} 