using Aref.Domain.Models.Captcha;
using Aref.Domain.ViewModels.CaptchaSetting;

namespace Aref.Application.Mappers.CaptchaMappings;

public static class CaptchaSettingMapper
{
    public static AdminCaptchaSettingViewModel ToAdminCaptchaSettingViewModel(this CaptchaSetting model) =>
        new()
        {
            CaptchaSection = model.CaptchaSection,
            CaptchaType = model.CaptchaType
        };

    public static CaptchaSetting ToCaptchaSetting(this AdminCaptchaSettingViewModel viewModel) =>
        new()
        {
            CaptchaType = viewModel.CaptchaType,
            CaptchaSection = viewModel.CaptchaSection
        };
}