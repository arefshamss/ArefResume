using Aref.Application.Mappers.PageContentMappings;
using Aref.Application.Services.Interfaces;
using Aref.Domain.Contracts;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.PageContentSetting.Admin;

namespace Aref.Application.Services.Implementations;

public class PageContentSettingService(IPageContentSettingRepository pageContentSettingRepository) : IPageContentSettingService
{
    #region Admin
    
    #region FillModelForUpdateAsync

    public async Task<Result<AdminUpdatePageContentSettingViewModel>> FillModelForUpdateAsync(short id)
    {
        if (id < 1) return Result.Failure<AdminUpdatePageContentSettingViewModel>(ErrorMessages.SomethingWentWrong);

        var item = await pageContentSettingRepository.FirstOrDefaultAsync(s => s.Id == id);

        if (item is null) return Result.Failure<AdminUpdatePageContentSettingViewModel>(ErrorMessages.NotFoundError);

        var result = item.MapToAdminUpdatePageContentSettingViewModel();

        return result;
    }

    #endregion

    #region UpdateAsync

    public async Task<Result> UpdateAsync(AdminUpdatePageContentSettingViewModel viewModel)
    {
        if (viewModel.Id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);

        var item = await pageContentSettingRepository.FirstOrDefaultAsync(s => s.Id == viewModel.Id);

        if (item is null) return Result.Failure(ErrorMessages.NotFoundError);

        viewModel.MapToPageContentSetting(item);

        pageContentSettingRepository.Update(item);
        await pageContentSettingRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.UpdateSuccessfullyDone);
    }

    #endregion

    #endregion
}