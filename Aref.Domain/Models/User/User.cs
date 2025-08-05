using Aref.Domain.Models.Common;
using Aref.Domain.Models.Role;

namespace Aref.Domain.Models.User;

public sealed class User : BaseEntity
{
    #region Properties

    public string? AvatarImageName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Mobile { get; set; }
    public string? Mobile2 { get; set; }
    public string? Email { get; set; }
    public DateTime? Birthday { get; set; }
    public string? Password { get; set; }
    public string? Notes { get; set; }
    public string? Address { get; set; }

    #endregion

    #region Relations
    
    public ICollection<UserRoleMapping> UserRoleMappings { get; set; }  

    #endregion
}