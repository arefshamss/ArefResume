using Aref.Domain.Models.Captcha;
using Aref.Domain.ViewModels.Captcha;

namespace Resume.Application.Mapper.CaptchaMappings;

public static class CaptchaMapper
{
    public static AdminCaptchaViewModel ToAdminCaptchaViewModel(this Captcha model) =>
        new()
        {
            Id = model.Id,
            CaptchaType = model.CaptchaType,
            IsActive = model.IsActive,
        };

    public static Captcha ToCaptcha(this AdminCreateCaptchaViewModel viewModel) =>
        new()
        {
            IsActive = viewModel.IsActive,
            CaptchaType = viewModel.CaptchaType,
            SiteKey = viewModel.SiteKey,
            SecretKey = viewModel.SecretKey,
        };

    public static AdminUpdateCaptchaViewModel ToAdminUpdateCaptchaViewModel(this Captcha model) =>
        new()
        {
            Id = model.Id,
            CaptchaType = model.CaptchaType,
            IsActive = model.IsActive,
            SecretKey = model.SecretKey,
            SiteKey = model.SiteKey
        };

    public static void ToCaptcha(this AdminUpdateCaptchaViewModel viewModel, Captcha model)
    {
        model.IsActive = viewModel.IsActive;
        model.SiteKey = viewModel.SiteKey;
        model.SecretKey = viewModel.SecretKey;
    }

    public static ClientCaptchaViewModel ToClientCaptchaViewModel(this Captcha model) =>
        new()
        {
            CaptchaType = model.CaptchaType,
            SecretKey = model.SecretKey,
            SiteKey = model.SiteKey
        };
}