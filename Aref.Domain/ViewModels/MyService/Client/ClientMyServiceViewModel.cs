namespace Aref.Domain.ViewModels.MyService.Client;

public class ClientMyServiceViewModel
{
    public short Id { get; set; }

    public string Title { get; set; }
    
    public string? Description { get; set; }

    public string IconName { get; set; }
    
    public short DisplayPriority { get; set; }
}