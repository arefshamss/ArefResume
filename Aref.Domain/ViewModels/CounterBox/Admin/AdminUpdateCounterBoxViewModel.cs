using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;

namespace Aref.Domain.ViewModels.CounterBox.Admin;

public class AdminUpdateCounterBoxViewModel
{
    public short Id { get; set; }


    [Display(Name = "Title")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(50, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Title { get; set; }
    
    
    [Display(Name = "Count")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    public int Count { get; set; }
    
    [Display(Name = "Display Priority")]
    public short DisplayPriority { get; set; }
}