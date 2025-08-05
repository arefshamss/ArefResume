using Aref.Domain.Models.Role;

namespace Aref.Infra.Data.Seeds;

public static class RoleSeeds
{
    public static List<Role> Roles =
    [
        new()
        {
            Id = 1,
            Name = "Admin",
            CreatedDate = SeedStaticDateTime.Date,
            IsDeleted = false
        }
    ];
}