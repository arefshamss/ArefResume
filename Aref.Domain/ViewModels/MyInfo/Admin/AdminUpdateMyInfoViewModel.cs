using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Aref.Domain.ViewModels.MyInfo.Admin;

public class AdminUpdateMyInfoViewModel
{
    public short Id { get; set; }
    
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(300, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string ImageUrl { get; set; }
    
    
    [MaxLength(300, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? CvUrl { get; set; }
    
    
    [Display(Name = "Image")]
    public IFormFile? Image { get; set; }    
    
    [Display(Name = "Cv")]
    public IFormFile? Cv { get; set; }

    [Display(Name = "Title")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(100, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Title { get; set; }
    
    
    [Display(Name = "Mobile")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(20, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Mobile { get; set; }    
    
    [Display(Name = "Email")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(100, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Email { get; set; }  
    
    [Display(Name = "FullName")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(100, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string FullName { get; set; }

    
    [Display(Name = "Mobile Visibility")]
    public bool MobileVisibility { get; set; }  
    
    [Display(Name = "Email Visibility")]
    public bool EmailVisibility { get; set; }    
    
    [Display(Name = "CV Visibility")]
    public bool CvVisibility { get; set; }    
    
    [Display(Name = "Title Visibility")]
    public bool TitleVisibility { get; set; }   

}