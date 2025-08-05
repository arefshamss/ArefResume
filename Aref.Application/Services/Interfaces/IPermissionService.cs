using Aref.Domain.ViewModels.Permission.Admin;

namespace Aref.Application.Services.Interfaces;

public interface IPermissionService
{
    Task<bool> CheckUserPermissionAsync(int userId, string permissionName);

    Task<bool> CheckUserPermissionAsync(int userId, IEnumerable<string> permissionNames);   

    Task<IReadOnlyList<AdminPermissionViewModel>> GetPermissionsAsync();
}