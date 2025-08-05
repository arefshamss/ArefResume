using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Aref.Domain.ViewModels.SocialMedia.Admin;

public class AdminCreateSocialMediaViewModel
{
    [Display(Name = "Title")]
    [MaxLength(100, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Title { get; set; }
    
    [Display(Name = "Link")]
    [MaxLength(500, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Link { get; set; }

    [Display(Name = "Visibility")] public bool IsVisible { get; set; } = true;
    
    [Display(Name = "Icon")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    public IFormFile Icon { get; set; }
    
    [Display(Name = "Display Priority")]
    public short DisplayPriority { get; set; }
}