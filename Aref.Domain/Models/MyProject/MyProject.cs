using Aref.Domain.Models.Common;

namespace Aref.Domain.Models.MyProject;

public class MyProject:BaseEntity<short>
{
    public required string Title { get; set; }
    
    public required string Link { get; set; }
    
    public string? SecondLink { get; set; }
    
    public string LinkButtonTitle { get; set; }
    
    public string? SecondLinkButtonTitle { get; set; }
    
    public string Developer { get; set; }
    
    public string ImageUrl { get; set; }
    
    public short DisplayPriority { get; set; }
}