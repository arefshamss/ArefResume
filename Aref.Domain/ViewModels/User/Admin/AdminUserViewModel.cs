namespace Aref.Domain.ViewModels.User.Admin;

public class AdminUserViewModel
{
    public int Id { get; set; } 
    public string? AvatarImageName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Mobile { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedDate { get; set; }  
    public bool IsDeleted { get; set; }

    #region Helpers

    public string FullName => $"{FirstName} {LastName}";

    #endregion
}