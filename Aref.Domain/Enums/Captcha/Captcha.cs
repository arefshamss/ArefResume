using System.ComponentModel.DataAnnotations;

namespace Aref.Domain.Enums.Captcha;

public enum CaptchaType : byte
{
    [Display(Name = "Google Recaptcha V2")]
    GoogleRecaptchaV2,

    [Display(Name = "Google Recaptcha V3")]
    GoogleRecaptchaV3
}

public enum CaptchaSection : byte
{
    [Display(Name = "Account Section")]
    Account,
}