using System.ComponentModel.DataAnnotations;
using Aref.Domain.Enums.MyResume;
using Aref.Domain.Shared;

namespace Aref.Domain.ViewModels.MyResume.Admin;

public class AdminUpdateMyResumeViewModel
{
    public short Id { get; set; }

    [Display(Name = "Title")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(500, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Title { get; set; }
    
        
    [Display(Name = "ResumeType")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    public MyResumeType ResumeType { get; set; }
    
    [Display(Name = "Years")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(50, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Years { get; set; }


    [Display(Name = "Description")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(1000, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Description { get; set; }
    
    [Display(Name = "Display Priority")]
    public short DisplayPriority { get; set; }
}
