using Aref.Domain.Models.Common;

namespace Aref.Domain.Models.MyService;

public class MyService : BaseEntity<short>
{
    #region Properties

    public required string Title { get; set; }
    
    public string IconName { get; set; }
    
    public string? Description { get; set; }
    
    public short DisplayPriority { get; set; }

    #endregion
}