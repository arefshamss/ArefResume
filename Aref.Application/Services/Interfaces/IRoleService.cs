using Aref.Domain.Shared;
using Aref.Domain.ViewModels.Role.Admin;

namespace Aref.Application.Services.Interfaces;

public interface IRoleService
{
    #region Role

    Task<AdminFilterRolesViewModel> FilterAsync(AdminFilterRolesViewModel filter);

    Task<Result<AdminUpdateRoleViewModel>> FillModelForUpdateAsync(short id);
    
    Task<string> GetRoleIdsJoinByCommaAsync(int userId);

    Task<Result> CreateAsync(AdminCreateRoleViewModel viewModel);

    Task<Result> UpdateAsync(AdminUpdateRoleViewModel viewModel);

    Task<Result> DeleteOrRecoverAsync(short id);

    #endregion

    #region RolePermission

    Task<Result> SetPermissionToRoleAsync(AdminSetPermissionToRoleViewModel viewModel);

    Task<List<short>> GetRoleSelectedPermissionAsync(short roleId);

    #endregion

    #region UserRole

    Task<bool> IsUserAdminAsync(int userId);

    Task<Result> SetRoleToUserAsync(AdminSetRoleToUserViewModel viewModel);
    
    #endregion
}