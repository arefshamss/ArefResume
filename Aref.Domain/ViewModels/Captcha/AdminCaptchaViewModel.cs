using Aref.Domain.Enums.Captcha;

namespace Aref.Domain.ViewModels.Captcha;

public class AdminCaptchaViewModel
{
    public short Id { get; set; }

    public CaptchaType CaptchaType { get; set; }

    public bool IsActive { get; set; }
}