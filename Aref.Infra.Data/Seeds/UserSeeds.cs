using System.Security.Cryptography;
using Aref.Domain.Models.User;

namespace Aref.Infra.Data.Seeds;

public static class UserSeeds
{
    public static List<User> Users { get; } =
    [
        new()
        {
            Id = 1,
            FirstName = "Aref",
            LastName = "Shamspour",
            Mobile = "09001112233",
            CreatedDate = SeedStaticDateTime.Date,
            Password = HashPassword("admin")
        }
    ];
    
    private static string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, 100000, HashAlgorithmName.SHA512, 32);
        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }
}

