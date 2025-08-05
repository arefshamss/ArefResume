using Aref.Domain.Models.Common;

namespace Aref.Domain.Models.MyInfo;

public class MyInfo:BaseEntity<short>
{
    public required string FullName { get; set; }
    
    public required string Title { get; set; }
    
    public bool TitleVisibility { get; set; }
    
    public required string Mobile { get; set; }
    
    public bool MobileVisibility { get; set; }
    
    public required string Email { get; set; }    
    
    public bool EmailVisibility { get; set; }
    
    public string ImageUrl { get; set; }   
    
    public string? CvUrl { get; set; }
    
    public bool CvVisibility { get; set; }
}