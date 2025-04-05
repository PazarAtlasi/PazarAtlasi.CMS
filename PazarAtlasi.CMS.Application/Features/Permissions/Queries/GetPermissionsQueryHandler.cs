using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Application.Features.Permissions.Queries
{
    public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, List<PermissionDto>>
    {
        public async Task<List<PermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {
            // Dummy data
            return new List<PermissionDto>
            {
                new PermissionDto
                {
                    Id = 1,
                    Name = "Kullanıcı Yönetimi",
                    Description = "Kullanıcıları yönetme yetkisi",
                    Module = "Kullanıcılar",
                    IsActive = true,
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
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
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
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
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
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
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
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
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
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
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
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
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
            };
        }
    }
} 