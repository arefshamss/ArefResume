using Aref.Domain.Models.Common;

namespace Aref.Domain.Models.Permission;

public sealed class Permission : BaseEntity<short>
{
    #region Properties

    public string UniqueName { get; set; }
    
    public string DisplayName { get; set; }
    
    public short? ParentId { get; set; }

    #endregion

    #region Relations

    public Permission? Parent { get; set; } 
    public ICollection<RolePermissionMapping> RolePermissionMappings { get; set; }      

    #endregion
}