using Aref.Domain.Enums.Captcha;

namespace Aref.Domain.ViewModels.CaptchaSetting;

public class AdminCaptchaSettingViewModel
{
    public CaptchaType CaptchaType { get; set; }

    public CaptchaSection CaptchaSection { get; set; }
}