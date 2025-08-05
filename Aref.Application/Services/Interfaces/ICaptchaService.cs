using Aref.Domain.Enums.Captcha;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.Captcha;

namespace Aref.Application.Services.Interfaces;

public interface ICaptchaService
{
    Task<List<AdminCaptchaViewModel>> GetAllCaptchaAsync();
    Task<Result> CreateCaptchaAsync(AdminCreateCaptchaViewModel viewModel);
    Task<Result<AdminUpdateCaptchaViewModel>> FillModelForEditAsync(short id);
    Task<Result> UpdateCaptchaAsync(AdminUpdateCaptchaViewModel viewModel);

    Task<Result<ClientCaptchaViewModel>> GetCaptchaBySectionAsync(CaptchaSection section);

    Task<bool> VerifyCaptchaAsync(CaptchaType type, string? token, string secretKey);

    Task<CaptchaVerificationV2ResponseViewModel> VerifyGoogleV2Async(string token, string secret);

    Task<CaptchaVerificationV3ResponseViewModel> VerifyGoogleV3Async(string token, string secret);
}