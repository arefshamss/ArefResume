namespace Aref.Domain.ViewModels.CounterBox.Admin;

public class AdminCounterBoxViewModel
{
    public short Id { get; set; }

    public string Title { get; set; }
    
    public short DisplayPriority { get; set; }
    
    public int Count { get; set; }

    public bool IsDeleted { get; set; }
}