using Aref.Application.Cache;
using Aref.Application.Services.Interfaces;
using Aref.Application.Statics;
using Aref.Domain.Contracts;
using Aref.Domain.Enums.Captcha;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.Captcha;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Resume.Application.Mapper.CaptchaMappings;

namespace Aref.Application.Services.Implementations;

public class CaptchaService(
    ICaptchaRepository captchaRepository,
    ICaptchaSettingRepository captchaSettingRepository,
    HttpClient httpClient,
    ILogger<CaptchaService> logger,
    IMemoryCacheService memoryCacheService) : ICaptchaService
{
    public async Task<List<AdminCaptchaViewModel>> GetAllCaptchaAsync()
    {
        var captcha = await captchaRepository.GetAllAsync();
        return captcha.Select(s => s.ToAdminCaptchaViewModel()).ToList();
    }

    public async Task<Result> CreateCaptchaAsync(AdminCreateCaptchaViewModel viewModel)
    {
        if (await captchaRepository.AnyAsync(s => s.CaptchaType == viewModel.CaptchaType))
            return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "CaptchaType"));

        var captcha = viewModel.ToCaptcha();

        await captchaRepository.InsertAsync(captcha);
        await captchaRepository.SaveChangesAsync();
        await memoryCacheService.RemoveByPrefixAsync(CacheKeys.CaptchaPrefix);
        return Result.Success(SuccessMessages.InsertSuccessfullyDone);
    }

    public async Task<Result<AdminUpdateCaptchaViewModel>> FillModelForEditAsync(short id)
    {
        if (id < 1) return Result.Failure<AdminUpdateCaptchaViewModel>(ErrorMessages.BadRequestError);

        var model = await captchaRepository.GetByIdAsync(id);

        if (model is null) return Result.Failure<AdminUpdateCaptchaViewModel>(ErrorMessages.NotFoundError);

        return model.ToAdminUpdateCaptchaViewModel();
    }

    public async Task<Result> UpdateCaptchaAsync(AdminUpdateCaptchaViewModel viewModel)
    {
        if (viewModel.Id < 1) return Result.Failure(ErrorMessages.BadRequestError);

        if (await captchaRepository.AnyAsync(s => s.CaptchaType == viewModel.CaptchaType))
            return Result.Failure(ErrorMessages.BadRequestError);

        var modelFromDatabase = await captchaRepository.GetByIdAsync(viewModel.Id);

        if (modelFromDatabase is null) return Result.Failure(ErrorMessages.NotFoundError);

        viewModel.ToCaptcha(modelFromDatabase);

        captchaRepository.Update(modelFromDatabase);
        await captchaRepository.SaveChangesAsync();
        await memoryCacheService.RemoveByPrefixAsync(CacheKeys.CaptchaPrefix);
        return Result.Success(SuccessMessages.UpdateSuccessfullyDone);
    }

    public async Task<Result<ClientCaptchaViewModel>> GetCaptchaBySectionAsync(CaptchaSection section)
    {
        return await memoryCacheService.GetOrCreateAsync(CacheKey.Format(CacheKeys.Captcha, section), async () =>
        {
            var captchaSetting = await captchaSettingRepository.FirstOrDefaultAsync(s => s.CaptchaSection == section);

            var captcha =
                await captchaRepository.FirstOrDefaultAsync(s =>
                    s.IsActive && s.CaptchaType == captchaSetting!.CaptchaType);

            return captcha!.ToClientCaptchaViewModel();
        });
    }

    public async Task<bool> VerifyCaptchaAsync(CaptchaType type, string? token, string secretKey)
    {
        switch (type)
        {
            case CaptchaType.GoogleRecaptchaV2:
                var v2Result = await VerifyGoogleV2Async(token, secretKey);
                return v2Result.Success;
            case CaptchaType.GoogleRecaptchaV3:
                var v3Result = await VerifyGoogleV3Async(token, secretKey);
                return v3Result.Success;
        }

        return false;
    }

    public async Task<CaptchaVerificationV2ResponseViewModel> VerifyGoogleV2Async(string token, string secret)
    {
        var response = await httpClient.GetAsync<CaptchaVerificationV2ResponseViewModel>(ApiUrls.GoogleRecaptcha, new
        {
            secret,
            response = token,
        });
        if (!response.IsSuccess)
        {
            logger.LogError("Failed to request to google captcha reason : \n " + response.Message);
            return new()
            {
                Success = false
            };
        }


        return response.Result;
    }

    public async Task<CaptchaVerificationV3ResponseViewModel> VerifyGoogleV3Async(string token, string secret)
    {
        var response = await httpClient.GetAsync<CaptchaVerificationV3ResponseViewModel>(ApiUrls.GoogleRecaptcha, new
        {
            secret,
            response = token,
        });
        if (!response.IsSuccess)
            logger.LogError("failed to request to google captcha reason : \n " + response.Message);

        return response.Result;
    }
}