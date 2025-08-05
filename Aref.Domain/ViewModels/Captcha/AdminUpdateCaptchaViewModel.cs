using System.ComponentModel.DataAnnotations;
using Aref.Domain.Enums.Captcha;
using Aref.Domain.Shared;

namespace Aref.Domain.ViewModels.Captcha;

public class AdminUpdateCaptchaViewModel
{
    public short Id { get; set; }

    [Display(Name = "Site Key")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(450, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string SiteKey { get; set; }

    [Display(Name = "Secret Key")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(450, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string SecretKey { get; set; }

    [Display(Name = "Captcha Type")]
    public CaptchaType CaptchaType { get; set; }

    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }
}