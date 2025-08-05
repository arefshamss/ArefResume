namespace Aref.Domain.ViewModels.Permission.Admin;

public class AdminPermissionViewModel
{
    public short Id { get; set; }
    public short? ParentId { get; set; }
    public string DisplayName { get; set; }
}