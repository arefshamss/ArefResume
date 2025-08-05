using Aref.Domain.Models.Common;

namespace Aref.Domain.Models.MySkill;

public class MySkill:BaseEntity<short>
{
    public string? SubTitle { get; set; }
    
    public required string Title { get; set; }
    
    public short Percent { get; set; }
    
    public string ImageUrl { get; set; }
    
    public short DisplayPriority { get; set; }
}