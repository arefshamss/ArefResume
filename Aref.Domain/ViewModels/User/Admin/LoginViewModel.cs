using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.Captcha;
using Aref.Domain.ViewModels.Common;

namespace Aref.Domain.ViewModels.User.Admin;

public class LoginViewModel : ClientCaptchaViewModel
{
    [Display(Name = "Mobile")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(11, ErrorMessage = ErrorMessages.MaxLengthError)]
    [RegularExpression(SiteRegex.MobileRegex, ErrorMessage = ErrorMessages.NotValid)]
    public string Mobile { get; set; }
    
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [MaxLength(500, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Password { get; set; }   
    
    public bool RememberMe { get; set; }
}