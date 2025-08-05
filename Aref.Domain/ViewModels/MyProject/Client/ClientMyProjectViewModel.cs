namespace Aref.Domain.ViewModels.MyProject.Client;

public class ClientMyProjectViewModel
{
    public short Id { get; set; }

    public string Title { get; set; }
    
    public string Link { get; set; }
    
    public string? SecondLink { get; set; }    

    public string LinkButtonTitle { get; set; } 
    
    public string? SecondLinkButtonTitle { get; set; }  
    
    public string Developer { get; set; }    

    public string ImageUrl { get; set; }
    
    public short DisplayPriority { get; set; }
}