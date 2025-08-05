using Aref.Domain.Enums.MyResume;

namespace Aref.Domain.ViewModels.MyResume.Admin;

public class AdminMyResumeViewModel
{
    public short Id { get; set; }

    public string Title { get; set; }
    
    public MyResumeType ResumeType { get; set; }
    
    public string Years { get; set; }    
    
    public string Description { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public short DisplayPriority { get; set; }
}