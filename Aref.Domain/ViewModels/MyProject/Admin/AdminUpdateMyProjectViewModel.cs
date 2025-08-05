using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Aref.Domain.ViewModels.MyProject.Admin;

public class AdminUpdateMyProjectViewModel
{
    public short Id { get; set; }
    
    public string ImageUrl { get; set; }
    
    [Display(Name = "Image")]
    public IFormFile? Image { get; set; }

    [Display(Name = "Title")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(300, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Title { get; set; }
    
    [Display(Name = "Link")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(300, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Link { get; set; } 
    
    [Display(Name = "Second Link")]
    [MaxLength(300, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? SecondLink { get; set; }    
    
    
    [Display(Name = "Link Button Title")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(20, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string LinkButtonTitle { get; set; } 
    
    
    [Display(Name = "Second Link Button Title")]
    [MaxLength(20, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? SecondLinkButtonTitle { get; set; }  
    
    
    [Display(Name = "Developer")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(50, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Developer { get; set; }    
    
    [Display(Name = "Display Priority")]
    public short DisplayPriority { get; set; }
}