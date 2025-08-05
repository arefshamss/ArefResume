using Aref.Domain.Models.Permission;
using Aref.Domain.ViewModels.Permission.Admin;

namespace Aref.Application.Mappers.PermissionMappings;

public static class PermissionMapper
{
    public static AdminPermissionViewModel MapToPermissionViewModel(this Permission permission) => new()
    {
        Id = permission.Id,
        DisplayName = permission.DisplayName,
        ParentId = permission.ParentId
    };
}