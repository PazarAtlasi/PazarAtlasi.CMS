using Microsoft.AspNetCore.Mvc;
using PazarAtlasi.CMS.Application.Features.Permissions.Queries;
using MediatR;

namespace PazarAtlasi.CMS.Controllers
{
    public class PermissionsController : Controller
    {
        private readonly IMediator _mediator;

        public PermissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            // Test data
            var permissions = new List<PermissionDto>
            {
                new PermissionDto
                {
                    Id = 1,
                    Name = "Kullanıcı Yönetimi",
                    Description = "Kullanıcıları yönetme yetkisi",
                    Module = "Kullanıcılar",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new PermissionDto
                {
                    Id = 2,
                    Name = "Rol Yönetimi",
                    Description = "Rolleri yönetme yetkisi",
                    Module = "Kullanıcılar",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new PermissionDto
                {
                    Id = 3,
                    Name = "İzin Yönetimi",
                    Description = "İzinleri yönetme yetkisi",
                    Module = "Kullanıcılar",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new PermissionDto
                {
                    Id = 4,
                    Name = "İçerik Yönetimi",
                    Description = "İçerikleri yönetme yetkisi",
                    Module = "İçerik",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new PermissionDto
                {
                    Id = 5,
                    Name = "Duyuru Yönetimi",
                    Description = "Duyuruları yönetme yetkisi",
                    Module = "İçerik",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new PermissionDto
                {
                    Id = 6,
                    Name = "Kampanya Yönetimi",
                    Description = "Kampanyaları yönetme yetkisi",
                    Module = "İçerik",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new PermissionDto
                {
                    Id = 7,
                    Name = "İçerik Görüntüleme",
                    Description = "İçerikleri görüntüleme yetkisi",
                    Module = "İçerik",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
            };

            return View(permissions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePermissionCommand command)
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
            var permission = new PermissionDto
            {
                Id = id,
                Name = "Kullanıcı Yönetimi",
                Description = "Kullanıcıları yönetme yetkisi",
                Module = "Kullanıcılar",
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            };

            return View(permission);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdatePermissionCommand command)
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
            await _mediator.Send(new DeletePermissionCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
} 