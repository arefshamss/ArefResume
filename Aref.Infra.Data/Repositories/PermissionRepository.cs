using Aref.Domain.Contracts;
using Aref.Domain.Models.Permission;
using Aref.Infra.Data.Context;
using Aref.Infra.Data.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace Aref.Infra.Data.Repositories;

public class PermissionRepository(ArefContext context) : EfRepository<Permission, short>(context), IPermissionRepository
{
    public async Task<List<RolePermissionMapping>> GetAllRolePermissions() => 
        await context.RolePermissionMappings
            .Include(s => s.Permission)
            .Include(c => c.Role)
            .ToListAsync();
}