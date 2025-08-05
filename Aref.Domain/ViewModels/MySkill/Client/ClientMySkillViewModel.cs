namespace Aref.Domain.ViewModels.MySkill.Client;

public class ClientMySkillViewModel
{
    public short Id { get; set; }

    public string Title { get; set; }
    
    public short Percent { get; set; }
    
    public string? SubTitle { get; set; }

    public string ImageUrl { get; set; }
    
    public short DisplayPriority { get; set; }
}