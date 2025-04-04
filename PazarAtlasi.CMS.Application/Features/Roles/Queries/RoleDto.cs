using MediatR;
using System;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Application.Features.Roles.Queries
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public List<string> Permissions { get; set; }
    }

    public class GetRolesQuery : IRequest<List<RoleDto>>
    {
    }

    public class GetRoleByIdQuery : IRequest<RoleDto>
    {
        public int Id { get; set; }
    }

    public class CreateRoleCommand : IRequest<RoleDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<int> PermissionIds { get; set; }
    }

    public class UpdateRoleCommand : IRequest<RoleDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<int> PermissionIds { get; set; }
    }

    public class DeleteRoleCommand : IRequest
    {
        public int Id { get; set; }
    }
} 