using Aref.Domain.Contracts;
using Aref.Domain.Models.Permission;
using Aref.Domain.Models.Role;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace Aref.Infra.Data.Repositories;

public class RoleRepository(ArefContext context) : EfRepository<Role, short>(context), IRoleRepository
{
    public async Task InsertPermissionsToRoleAsync(List<RolePermissionMapping> permissions) =>
        await context.RolePermissionMappings.AddRangeAsync(permissions);

    public async Task DeleteRolePermissionsByIdAsync(short roleId) =>
        await context.RolePermissionMappings.Where(s => s.RoleId == roleId).ExecuteDeleteAsync();

    public async Task<List<short>> GetSelectedPermission(short roleId) =>
        await context.RolePermissionMappings.Where(s => s.RoleId == roleId)
            .Select(s => s.PermissionId).ToListAsync();
}