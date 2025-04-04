using MediatR;
using System;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Application.Features.Permissions.Queries
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Module { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class GetPermissionsQuery : IRequest<List<PermissionDto>>
    {
    }

    public class GetPermissionByIdQuery : IRequest<PermissionDto>
    {
        public int Id { get; set; }
    }

    public class CreatePermissionCommand : IRequest<PermissionDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Module { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdatePermissionCommand : IRequest<PermissionDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Module { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeletePermissionCommand : IRequest
    {
        public int Id { get; set; }
    }
} 