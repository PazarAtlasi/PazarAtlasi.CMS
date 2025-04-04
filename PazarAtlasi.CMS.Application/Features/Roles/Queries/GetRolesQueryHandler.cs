using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Application.Features.Roles.Queries
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RoleDto>>
    {
        public async Task<List<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            // Dummy data
            return new List<RoleDto>
            {
                new RoleDto
                {
                    Id = 1,
                    Name = "Admin",
                    Description = "Sistem yöneticisi",
                    IsActive = true,
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
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
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
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
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                    Permissions = new List<string> { "İçerik Görüntüleme" }
                }
            };
        }
    }
} 