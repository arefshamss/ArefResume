using Aref.Application.Cache;
using Aref.Application.Mappers.CaptchaMappings;
using Aref.Application.Services.Interfaces;
using Aref.Domain.Contracts;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.CaptchaSetting;
using Microsoft.Extensions.Localization;
using Resume.Application.Mapper.CaptchaMappings;

namespace Aref.Application.Services.Implementations;

public class CaptchaSettingService(ICaptchaSettingRepository captchaSettingRepository,
    IMemoryCacheService memoryCacheService) : ICaptchaSettingService
{
    public async Task<AdminUpdateCaptchaSettingViewModel> FillModelForEditAsync()
    {
        var captchaSettings = await captchaSettingRepository.GetAllAsync();
        return new AdminUpdateCaptchaSettingViewModel
        {
            CaptchaSettings = captchaSettings.Select(s => s.ToAdminCaptchaSettingViewModel()).ToList()
        };
    }

    public async Task<Result> UpdateCaptchaSettingsAsync(AdminUpdateCaptchaSettingViewModel viewModel)
    {
        foreach (var captchaSection in viewModel.CaptchaSettings)
        {
            var captchaSetting =
                await captchaSettingRepository.FirstOrDefaultAsync(s =>
                    s.CaptchaSection == captchaSection.CaptchaSection);
            if (captchaSetting is null)
            {
                captchaSetting = captchaSection.ToCaptchaSetting();
                await captchaSettingRepository.InsertAsync(captchaSetting);
            }
            else
            {
                captchaSetting.CaptchaType = captchaSection.CaptchaType;
                captchaSettingRepository.Update(captchaSetting);
            }
        }

        await captchaSettingRepository.SaveChangesAsync();
        await memoryCacheService.RemoveByPrefixAsync(CacheKeys.CaptchaPrefix);
        return Result.Success(SuccessMessages.SavedChangesSuccessfully);
    }
}