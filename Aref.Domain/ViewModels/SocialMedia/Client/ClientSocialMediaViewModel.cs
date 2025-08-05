namespace Aref.Domain.ViewModels.SocialMedia.Client;

public class ClientSocialMediaViewModel
{
    public short Id { get; set; }

    public string Title { get; set; }
    
    public bool IsVisible { get; set; }
    
    public string Link { get; set; }

    public string IconName { get; set; }
    
    public short DisplayPriority { get; set; }
}