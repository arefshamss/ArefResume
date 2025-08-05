using Aref.Domain.Contracts.Generics;
using Aref.Domain.Models.Permission;
using Aref.Domain.Models.Role;

namespace Aref.Domain.Contracts;

public interface IRoleRepository : IEfRepository<Role, short>
{
    Task InsertPermissionsToRoleAsync(List<RolePermissionMapping> permissions);

    Task DeleteRolePermissionsByIdAsync(short roleId);

    Task<List<short>> GetSelectedPermission(short roleId);
}