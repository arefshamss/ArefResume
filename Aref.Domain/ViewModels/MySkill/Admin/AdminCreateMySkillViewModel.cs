using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Aref.Domain.ViewModels.MySkill.Admin;

public class AdminCreateMySkillViewModel
{
    [Display(Name = "Title")]
    [MaxLength(100, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Title { get; set; }
    
    [Display(Name = "SubTitle")]
    [MaxLength(500, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? SubTitle { get; set; }    
    
    [Display(Name = "Percent")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [Range(0, 100, ErrorMessage = "Percent must be between 0 and 100.")]
    public short Percent { get; set; }    
    
    [Display(Name = "Image")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    public IFormFile Image { get; set; }
    
    [Display(Name = "Display Priority")]
    public short DisplayPriority { get; set; }
}