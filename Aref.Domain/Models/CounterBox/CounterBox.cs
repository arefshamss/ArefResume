using Aref.Domain.Models.Common;

namespace Aref.Domain.Models.CounterBox;

public class CounterBox: BaseEntity<short>
{
    #region Properties
    
    public int Count { get; set; }
    public string Title { get; set; }
    public short DisplayPriority { get; set; }
    
    #endregion
}