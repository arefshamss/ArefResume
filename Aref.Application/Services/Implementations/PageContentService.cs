using Aref.Application.Mappers.PageContentMappings;
using Aref.Application.Services.Interfaces;
using Aref.Domain.Contracts;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.PageContent.Admin;

namespace Aref.Application.Services.Implementations;

public class PageContentService(IPageContentRepository pageContentRepository) : IPageContentService
{
    #region Admin
    
    #region FillModelForUpdateAsync

    public async Task<Result<AdminUpdatePageContentViewModel>> FillModelForUpdateAsync(short id)
    {
        if (id < 1) return Result.Failure<AdminUpdatePageContentViewModel>(ErrorMessages.SomethingWentWrong);

        var item = await pageContentRepository.FirstOrDefaultAsync(s => s.Id == id);

        if (item is null) return Result.Failure<AdminUpdatePageContentViewModel>(ErrorMessages.NotFoundError);

        var result = item.MapToAdminUpdatePageContentViewModel();

        return result;
    }

    #endregion

    #region UpdateAsync

    public async Task<Result> UpdateAsync(AdminUpdatePageContentViewModel viewModel)
    {
        if (viewModel.Id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);

        var item = await pageContentRepository.FirstOrDefaultAsync(s => s.Id == viewModel.Id);

        if (item is null) return Result.Failure(ErrorMessages.NotFoundError);

        viewModel.MapToPageContent(item);

        pageContentRepository.Update(item);
        await pageContentRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.UpdateSuccessfullyDone);
    }

    #endregion

    #endregion
}