using Aref.Domain.Models.Role;

namespace Aref.Infra.Data.Seeds;

public static class UserRoleMappingSeeds
{
    public static List<UserRoleMapping> UserRoleMappings { get; } =
    [
        new()
        {
            Id = 1,
            UserId = 1,
            RoleId = 1,
            CreatedDate = SeedStaticDateTime.Date,
        }
    ];
}