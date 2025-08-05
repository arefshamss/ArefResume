namespace Aref.Domain.ViewModels.MyService.Admin;

public class AdminMyServiceViewModel
{
    public short Id { get; set; }

    public string Title { get; set; }

    public string IconName { get; set; }

    public bool IsDeleted { get; set; }  
    
    public short DisplayPriority { get; set; }
}