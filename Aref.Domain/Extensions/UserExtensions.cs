using Aref.Domain.Models.User;

namespace Aref.Domain.Extensions;

public static class UserExtensions
{
    public static string GetUserDisplayName(this User user)
    {
        if (user is { FirstName: not null, LastName: not null })
            return $"{user.FirstName} {user.LastName}";

        return user.Mobile ?? "Unknown User";
        return "Unknown User";
    }

    public static string GetUserFullName(this User user)
        => $"{user.FirstName} {user.LastName}";

}