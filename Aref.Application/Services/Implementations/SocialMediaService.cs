
using Aref.Application.Extensions;
using Aref.Application.Mappers.SocialMediaMappings;
using Aref.Application.Services.Interfaces;
using Aref.Application.Statics;
using Aref.Domain.Contracts;
using Aref.Domain.Enums.Common;
using Aref.Domain.Models.SocialMedia;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.SocialMedia.Admin;
using Aref.Domain.ViewModels.SocialMedia.Client;
using Microsoft.EntityFrameworkCore;

namespace Aref.Application.Services.Implementations;

public class SocialMediaService(
    ISocialMediaRepository socialMediaRepository) : ISocialMediaService
{
    #region Admin

    #region FilterAsync

    public async Task<AdminFilterSocialMediaViewModel> FilterAsync(AdminFilterSocialMediaViewModel filter)
    {
        #region Filter

        filter ??= new();

        var conditions = Filter.GenerateConditions<SocialMedia>();
        var orders = Filter.GenerateOrders<SocialMedia>();

        orders.Add(x => x.DisplayPriority);


        if (!string.IsNullOrEmpty(filter.Title))
            conditions.Add(s => EF.Functions.Like(s.Title, $"%{filter.Title.Trim()}%"));

        switch (filter.DeleteStatus)
        {
            case DeleteStatus.NotDeleted:
                conditions.Add(s => !s.IsDeleted);
                break;
            case DeleteStatus.All:
                break;
            case DeleteStatus.Deleted:
                conditions.Add(s => s.IsDeleted);
                break;
        }

        #endregion

        await socialMediaRepository.FilterAsync(filter, conditions, s => s.MapToAdminSocialMediaViewModel(),orders);
        return filter;
    }

    #endregion

    #region CreateAsync

    public async Task<Result> CreateAsync(AdminCreateSocialMediaViewModel viewModel)
    {
        if (viewModel.DisplayPriority < 1)
            return Result.Failure(string.Format(ErrorMessages.NotValid, "Display Priority"));
            
        if (await socialMediaRepository.AnyAsync(x => x.DisplayPriority == viewModel.DisplayPriority && !x.IsDeleted))
            return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));

        var socialMedia = viewModel.MapToSocialMedia();

        #region AddIcon

        var result = await viewModel.Icon.AddImageToServer(FilePaths.SocialMediaIconPath, suggestedFileName: viewModel.Title);

        if (result.IsFailure) return Result.Failure(result.Message!);

        socialMedia.IconName = result.Value;

        #endregion

        await socialMediaRepository.InsertAsync(socialMedia);
        await socialMediaRepository.SaveChangesAsync();
        
        return Result.Success(SuccessMessages.InsertSuccessfullyDone);
    }

    #endregion

    #region FillModelForUpdateAsync

    public async Task<Result<AdminUpdateSocialMediaViewModel>> FillModelForUpdateAsync(short id)
    {
        if (id < 1)
            return Result.Failure<AdminUpdateSocialMediaViewModel>(ErrorMessages.SomethingWentWrong);

        var socialMedia = await socialMediaRepository.FirstOrDefaultAsync(s => s.Id == id);

        if (socialMedia is null)
            return Result.Failure<AdminUpdateSocialMediaViewModel>(ErrorMessages.NotFoundError);

        var result = socialMedia.MapToAdminUpdateSocialMediaViewModel();

        return result;
    }

    #endregion

    #region UpdateAsync

    public async Task<Result> UpdateAsync(AdminUpdateSocialMediaViewModel viewModel)
    {
        if (viewModel.Id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);
        
        if (viewModel.DisplayPriority < 1)
            return Result.Failure(string.Format(ErrorMessages.NotValid, "Display Priority"));
        
        if (await socialMediaRepository.AnyAsync(x => x.DisplayPriority == viewModel.DisplayPriority && !x.IsDeleted && x.Id != viewModel.Id))
            return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        
        var socialMedia = await socialMediaRepository.FirstOrDefaultAsync(s => s.Id == viewModel.Id);

        if (socialMedia is null) return Result.Failure(ErrorMessages.NotFoundError);

        if (viewModel.Icon is not null)
        {
            var result = await viewModel.Icon.AddImageToServer(FilePaths.SocialMediaIconPath, deleteFileName: socialMedia.IconName);

            if (result.IsFailure) return Result.Failure(result.Message!);

            socialMedia.IconName = result.Value;
        }

        viewModel.MapToSocialMedia(socialMedia);

        socialMediaRepository.Update(socialMedia);
        await socialMediaRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.UpdateSuccessfullyDone);
    }

    #endregion

    #region DeleteOrRecoverAsync

    public async Task<Result> DeleteOrRecoverAsync(short id)
    {
        if (id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);

        var socialMedia = await socialMediaRepository.GetByIdAsync(id);

        if (socialMedia is null) return Result.Failure(ErrorMessages.NotFoundError);

        if (socialMedia.IsDeleted)
        {
            var hasDuplicate = await socialMediaRepository.AnyAsync(x =>
                x.DisplayPriority == socialMedia.DisplayPriority && !x.IsDeleted);

            if (hasDuplicate)
                return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        }
        
        socialMediaRepository.SoftDeleteOrRecover(socialMedia);
        await socialMediaRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.SuccessfullyDone);
    }

    #endregion

    #endregion

    #region Client

    #region FilterAsync

    public async Task<ClientFilterSocialMediaViewModel> FilterAsync(ClientFilterSocialMediaViewModel filter)
    {
        #region Filter

        filter ??= new();

        var conditions = Filter.GenerateConditions<SocialMedia>();
        var orders = Filter.GenerateOrders<SocialMedia>();

        orders.Add(x => x.DisplayPriority);
        
        switch (filter.DeleteStatus)
        {
            case DeleteStatus.NotDeleted:
                conditions.Add(s => !s.IsDeleted);
                break;
            case DeleteStatus.All:
                break;
            case DeleteStatus.Deleted:
                conditions.Add(s => s.IsDeleted);
                break;
        }

        #endregion

        await socialMediaRepository.FilterAsync(filter, conditions, s => s.MapToClientSocialMediaViewModel(),orders);
        return filter;
    }

#endregion

    #endregion
}

