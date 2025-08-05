using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Aref.Domain.ViewModels.MyService.Admin;

public class AdminCreateMyServiceViewModel
{
    [Display(Name = "Title")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(300, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Title { get; set; }    
    
    [Display(Name = "Description")]
    [MaxLength(600, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? Description { get; set; }
    
    [Display(Name = "Icon")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    public IFormFile Icon { get; set; }
    
    [Display(Name = "Display Priority")]
    public short DisplayPriority { get; set; }
}