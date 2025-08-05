namespace Aref.Domain.ViewModels.MySkill.Admin;

public class AdminMySkillViewModel
{
    public short Id { get; set; }

    public string Title { get; set; }

    public string ImageUrl { get; set; }
    
    public short Percent { get; set; }

    public bool IsDeleted { get; set; }  
    
    public short DisplayPriority { get; set; }
}