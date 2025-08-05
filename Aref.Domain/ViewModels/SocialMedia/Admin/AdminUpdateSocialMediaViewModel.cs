using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Aref.Domain.ViewModels.SocialMedia.Admin;

public class AdminUpdateSocialMediaViewModel
{
    public short Id { get; set; }
    
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(200, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string IconName { get; set; }
    
    [Display(Name = "Icon")]
    public IFormFile? Icon { get; set; }

    [Display(Name = "Title")]
    [MaxLength(100, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Title { get; set; }
    
    [Display(Name = "Visibility")]
    public bool IsVisible { get; set; }
    
    [Display(Name = "Link")]
    [MaxLength(500, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Link { get; set; }
    
    
    [Display(Name = "Display Priority")]
    public short DisplayPriority { get; set; }
}