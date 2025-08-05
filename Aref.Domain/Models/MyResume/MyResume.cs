using Aref.Domain.Enums.MyResume;
using Aref.Domain.Models.Common;

namespace Aref.Domain.Models.MyResume;

public class MyResume:BaseEntity<short>
{
    #region Properties

    public required string Title { get; set; }
    
    public required string Years { get; set; }
        
    public required string Description { get; set; }

    public MyResumeType ResumeType { get; set; }
    
    public short DisplayPriority { get; set; }
    
    #endregion
}