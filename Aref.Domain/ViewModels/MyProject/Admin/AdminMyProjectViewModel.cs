namespace Aref.Domain.ViewModels.MyProject.Admin;

public class AdminMyProjectViewModel
{
    public short Id { get; set; }

    public string Title { get; set; }
    
    public string Link { get; set; }
    
    public string? SecondLink { get; set; }    
    
    public string Developer { get; set; }    

    public bool IsDeleted { get; set; } 
    
    public short DisplayPriority { get; set; }
}