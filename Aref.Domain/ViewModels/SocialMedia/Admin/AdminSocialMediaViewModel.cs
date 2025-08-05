namespace Aref.Domain.ViewModels.SocialMedia.Admin;

public class AdminSocialMediaViewModel
{
    public short Id { get; set; }

    public string Title { get; set; }

    public string Link { get; set; }
    
    public bool IsVisible { get; set; }

    public bool IsDeleted { get; set; }  

    public short DisplayPriority { get; set; }
}