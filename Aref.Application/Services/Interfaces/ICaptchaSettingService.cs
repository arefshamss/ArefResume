using Aref.Domain.Shared;
using Aref.Domain.ViewModels.CaptchaSetting;

namespace Aref.Application.Services.Interfaces;

public interface ICaptchaSettingService
{
    Task<AdminUpdateCaptchaSettingViewModel> FillModelForEditAsync();

    Task<Result> UpdateCaptchaSettingsAsync(AdminUpdateCaptchaSettingViewModel viewModel);
}