using Microsoft.AspNetCore.Mvc;
using PazarAtlasi.CMS.Application.Features.Roles.Queries;
using MediatR;

namespace PazarAtlasi.CMS.Controllers
{
    public class RolesController : Controller
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            // Test data
            var roles = new List<RoleDto>
            {
                new RoleDto
                {
                    Id = 1,
                    Name = "Admin",
                    Description = "Sistem yöneticisi",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    Permissions = new List<string> { "Kullanıcı Yönetimi", "Rol Yönetimi", "İzin Yönetimi", "İçerik Yönetimi" }
                },
                new RoleDto
                {
                    Id = 2,
                    Name = "Editor",
                    Description = "İçerik editörü",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    Permissions = new List<string> { "İçerik Yönetimi", "Duyuru Yönetimi", "Kampanya Yönetimi" }
                },
                new RoleDto
                {
                    Id = 3,
                    Name = "User",
                    Description = "Normal kullanıcı",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    Permissions = new List<string> { "İçerik Görüntüleme" }
                }
            };

            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public IActionResult Edit(int id)
        {
            // Test data
            var role = new RoleDto
            {
                Id = id,
                Name = "Admin",
                Description = "Sistem yöneticisi",
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System",
                Permissions = new List<string> { "Kullanıcı Yönetimi", "Rol Yönetimi", "İzin Yönetimi", "İçerik Yönetimi" }
            };

            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateRoleCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteRoleCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
} 