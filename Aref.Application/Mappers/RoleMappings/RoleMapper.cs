using Aref.Domain.Models.Role;
using Aref.Domain.ViewModels.Role.Admin;

namespace Aref.Application.Mappers.RoleMappings;

public static class RoleMapper
{
    public static AdminRoleViewModel MapToRoleViewModel(this Role role) => new()
    {
        Id = role.Id,
        IsDeleted = role.IsDeleted,
        Name = role.Name
    };

    public static Role MapToRole(this AdminCreateRoleViewModel viewModel) => new()
    {
        Name = viewModel.Name
    };

    public static AdminUpdateRoleViewModel MapToUpdateRoleViewModel(this Role role) => new()
    {
        Name = role.Name,
        Id = role.Id
    };

    public static void MapToRole(this AdminUpdateRoleViewModel viewModel, Role model)
    {
        model.Name = viewModel.Name;
    }
}