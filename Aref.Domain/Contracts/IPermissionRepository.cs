using Aref.Domain.Contracts.Generics;
using Aref.Domain.Models.Permission;

namespace Aref.Domain.Contracts;

public interface IPermissionRepository : IEfRepository<Permission, short>
{
    Task<List<RolePermissionMapping>> GetAllRolePermissions();
}