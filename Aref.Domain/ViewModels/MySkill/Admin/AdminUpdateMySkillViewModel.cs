using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Aref.Domain.ViewModels.MySkill.Admin;

public class AdminUpdateMySkillViewModel
{
    public short Id { get; set; }
    
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    public string ImageUrl { get; set; }
    
    [Display(Name = "Image")]
    public IFormFile? Image { get; set; }

    [Display(Name = "Title")]
    [MaxLength(100, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Title { get; set; }
    
    [Display(Name = "Percent")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    public short Percent { get; set; }
    
    [Display(Name = "SubTitle")]
    [MaxLength(500, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? SubTitle { get; set; }
    
    [Display(Name = "Display Priority")]
    public short DisplayPriority { get; set; }
}