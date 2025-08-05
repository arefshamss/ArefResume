using Aref.Domain.ViewModels.Permission.Admin;

namespace Aref.Domain.ViewModels.Role.Admin;

public class AdminSetPermissionToRoleViewModel
{
    public short RoleId { get; set; }
    
    public List<short>? PermissionIds { get; set; }
    
    public List<short>? SelectedPermissionIds { get; set; }
    
    public IReadOnlyList<AdminPermissionViewModel>? Permissions { get; set; }   
}