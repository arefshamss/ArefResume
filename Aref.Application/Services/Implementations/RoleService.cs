using Aref.Application.Cache;
using Aref.Application.Services.Interfaces;
using Aref.Domain.Contracts;
using Aref.Domain.Enums.Common;
using Aref.Domain.Models.Permission;
using Aref.Domain.Models.Role;
using Aref.Domain.Shared;
using Aref.Application.Extensions;
using Aref.Application.Mappers.RoleMappings;
using Aref.Domain.ViewModels.Role.Admin;
using Microsoft.EntityFrameworkCore;

namespace Aref.Application.Services.Implementations;

public class RoleService(
    IRoleRepository roleRepository,
    IUserRoleMappingRepository userRoleMappingRepository,
    IMemoryCacheService memoryCacheService,
    IUserRepository userRepository) : IRoleService
{
    public async Task<AdminFilterRolesViewModel> FilterAsync(AdminFilterRolesViewModel filter)
    {
        filter ??= new();

        var conditions = Filter.GenerateConditions<Role>();

        #region Filter

        if (!string.IsNullOrEmpty(filter.Name))
            conditions.Add(c => EF.Functions.Like(c.Name, $"%{filter.Name.Trim()}%"));

        switch (filter.DeleteStatus)
        {
            case DeleteStatus.NotDeleted:
                conditions.Add(c => !c.IsDeleted);
                break;
            case DeleteStatus.All:
                break;
            case DeleteStatus.Deleted:
                conditions.Add(c => c.IsDeleted);
                break;
        }

        #endregion

        await roleRepository.FilterAsync(filter, conditions, c => c.MapToRoleViewModel());
        return filter;
    }

    public async Task<Result> CreateAsync(AdminCreateRoleViewModel viewModel)
    {
        var role = viewModel.MapToRole();

        await roleRepository.InsertAsync(role);
        await roleRepository.SaveChangesAsync();

        await memoryCacheService.RemoveAsync(CacheKeys.RolePermissionMappings);

        return Result.Success(SuccessMessages.SuccessfullyDone);
    }

    public async Task<Result> UpdateAsync(AdminUpdateRoleViewModel viewModel)
    {
        if (viewModel.Id < 2)
            return Result.Failure(ErrorMessages.OperationFailedError);

        var role = await roleRepository.GetByIdAsync(viewModel.Id);

        if (role is null)
            return Result.Failure(ErrorMessages.NotFoundError);

        viewModel.MapToRole(role);

        roleRepository.Update(role);
        await roleRepository.SaveChangesAsync();

        await memoryCacheService.RemoveAsync(CacheKeys.RolePermissionMappings);

        return Result.Success(SuccessMessages.SuccessfullyDone);
    }

    public async Task<Result<AdminUpdateRoleViewModel>> FillModelForUpdateAsync(short id)
    {
        if (id < 1)
            return Result.Failure<AdminUpdateRoleViewModel>(ErrorMessages.OperationFailedError);

        var role = await roleRepository.GetByIdAsync(id);

        if (role is null)
            return Result.Failure<AdminUpdateRoleViewModel>(ErrorMessages.NotFoundError);

        var model = role.MapToUpdateRoleViewModel();

        return model;
    }

    public async Task<Result> DeleteOrRecoverAsync(short id)
    {
        if (id < 2)
            return Result.Failure(ErrorMessages.OperationFailedError);

        var role = await roleRepository.GetByIdAsync(id);

        if (role is null)
            return Result.Failure(ErrorMessages.NotFoundError);

        roleRepository.SoftDeleteOrRecover(role);
        await roleRepository.SaveChangesAsync();

        await memoryCacheService.RemoveAsync(CacheKeys.RolePermissionMappings);

        return Result.Success(SuccessMessages.SuccessfullyDone);
    }

    public async Task<Result> SetPermissionToRoleAsync(AdminSetPermissionToRoleViewModel viewModel)
    {
        if (viewModel.RoleId < 1)
            return Result.Failure(ErrorMessages.OperationFailedError);

        await roleRepository.DeleteRolePermissionsByIdAsync(viewModel.RoleId);
        var rolePermission = new List<RolePermissionMapping>();

        if (viewModel.PermissionIds is not null && viewModel.PermissionIds?.Count > 0)
        {
            foreach (var permissionId in viewModel.PermissionIds)
            {
                rolePermission.Add(new(roleId: viewModel.RoleId, permissionId: permissionId));
            }

            await roleRepository.InsertPermissionsToRoleAsync(rolePermission);
        }

        await roleRepository.SaveChangesAsync();

        await memoryCacheService.RemoveAsync(CacheKeys.RolePermissionMappings);

        return Result.Success(SuccessMessages.SavedChangesSuccessfully);
    }

    public async Task<List<short>> GetRoleSelectedPermissionAsync(short roleId) =>
        await roleRepository.GetSelectedPermission(roleId);

    public async Task<bool> IsUserAdminAsync(int userId) =>
        await roleRepository.AnyAsync(s => s.UserRoleMappings.Any(item => item.UserId == userId));

    public async Task<string> GetRoleIdsJoinByCommaAsync(int userId)
    {
        if (userId < 1) return string.Empty;

        var roleIds = await userRoleMappingRepository.GetAllAsync(s => s.RoleId, s => s.UserId == userId && !s.Role.IsDeleted);

        if (roleIds is null) return string.Empty;

        return string.Join(",", roleIds);
    }

    public async Task<Result> SetRoleToUserAsync(AdminSetRoleToUserViewModel viewModel)
    {
        if (viewModel.UserId < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);

        var user = await userRepository.GetByIdAsync(viewModel.UserId);

        if (user is null) return Result.Failure(ErrorMessages.UserNotFoundError);

        await userRoleMappingRepository.ExecuteDeleteRange(s => s.UserId == viewModel.UserId);

        var roleIds = viewModel.RoleIds?.ConvertStringToShortList();

        if (roleIds is not null && roleIds.Any())
        {
            var userRoleMappings = roleIds.Select(s => new UserRoleMapping
            {
                UserId = viewModel.UserId,
                RoleId = s
            }).ToList();
            
            await userRoleMappingRepository.InsertRangeAsync(userRoleMappings);
            await userRoleMappingRepository.SaveChangesAsync();
        }

        return Result.Success(SuccessMessages.SuccessfullyDone);
    }
}