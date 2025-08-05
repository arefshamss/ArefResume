using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace Aref.Domain.ViewModels.User.Admin;

public class AdminUpdateUserViewModel
{
    public int Id { get; set; } 
    
    [Display(Name = "Profile Picture")]
    public IFormFile? AvatarImageFile { get; set; }
    public string? AvatarImageName { get; set; }    
    
    [Display(Name = "First Name")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(50, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string FirstName { get; set; }
    
    [Display(Name = "Last Name")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(50, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string LastName { get; set; }
    
    [Display(Name = "Mobile")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [RegularExpression(SiteRegex.MobileRegex, ErrorMessage = ErrorMessages.NotValid)]
    public string Mobile { get; set; }   
    
    [Display(Name = "Mobile 2")]
    [RegularExpression(SiteRegex.MobileRegex, ErrorMessage = ErrorMessages.NotValid)]
    public string? Mobile2 { get; set; } 
    
    [Display(Name = "Email")]
    [RegularExpression(SiteRegex.EmailRegex, ErrorMessage = ErrorMessages.NotValid)]
    public string? Email { get; set; }

    [Display(Name = "Password")]
    [MaxLength(500, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? Password { get; set; } 
    
    public DateTime? Birthday { get; set; }
    
    [Display(Name = "Notes")]
    [MaxLength(400, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? Notes { get; set; }
    
    [Display(Name = "Address")]
    [MaxLength(400, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? Address { get; set; }
}