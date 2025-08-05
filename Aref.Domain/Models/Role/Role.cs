using Aref.Domain.Models.Common;
using Aref.Domain.Models.Permission;

namespace Aref.Domain.Models.Role;

public sealed class Role : BaseEntity<short>    
{
    #region Properties

    public string Name { get; set; }    

    #endregion

    #region Relations

    public ICollection<RolePermissionMapping> RolePermissionMappings { get; set; }  
    public ICollection<UserRoleMapping> UserRoleMappings { get; set; }  

    #endregion
}