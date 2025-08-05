using Aref.Application.Mappers.MyResumeMappings;
using Aref.Application.Services.Interfaces;
using Aref.Domain.Contracts;
using Aref.Domain.Enums.Common;
using Aref.Domain.Enums.MyResume;
using Aref.Domain.Models.MyResume;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.MyResume.Admin;
using Aref.Domain.ViewModels.MyResume.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Aref.Application.Services.Implementations;

public class MyResumeService(
    IMyResumeRepository myResumeRepository
) : IMyResumeService
{
    #region Admin

    #region FilterAsync

    public async Task<AdminFilterMyResumeViewModel> FilterAsync(AdminFilterMyResumeViewModel filter)
    {
        #region Filter

        filter ??= new();

        var conditions = Filter.GenerateConditions<MyResume>();
        var orders = Filter.GenerateOrders<MyResume>();

        orders.Add(x => x.ResumeType);
        orders.Add(x => x.DisplayPriority);


        if (!string.IsNullOrEmpty(filter.Title))
            conditions.Add(s => EF.Functions.Like(s.Title, $"%{filter.Title.Trim()}%"));

        switch (filter.ResumeType)
        {
            case FilterMyResumeType.All:
                break;
            case FilterMyResumeType.None:
                conditions.Add(s => s.ResumeType == MyResumeType.None);
                break;
            case FilterMyResumeType.Education:
                conditions.Add(s => s.ResumeType == MyResumeType.Education);
                break;
            case FilterMyResumeType.Experience:
                conditions.Add(s => s.ResumeType == MyResumeType.Experience);
                break;
            case FilterMyResumeType.Courses:
                conditions.Add(s => s.ResumeType == MyResumeType.Courses);
                break;
        }
        
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

        await myResumeRepository.FilterAsync(filter, conditions, s => s.MapToAdminMyResumeViewModel(),orders);
        return filter;
    }

    #endregion

    #region CreateAsync

    public async Task<Result> CreateAsync(AdminCreateMyResumeViewModel viewModel)
    {
        if (viewModel.DisplayPriority < 1)
            return Result.Failure(string.Format(ErrorMessages.NotValid, "Display Priority"));
        
        if (await myResumeRepository.AnyAsync(x => x.DisplayPriority == viewModel.DisplayPriority && x.ResumeType == viewModel.ResumeType && !x.IsDeleted))
            return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        
        var item = viewModel.MapToMyResume();

        await myResumeRepository.InsertAsync(item);
        await myResumeRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.InsertSuccessfullyDone);
    }

    #endregion

    #region FillModelForUpdateAsync

    public async Task<Result<AdminUpdateMyResumeViewModel>> FillModelForUpdateAsync(short id)
    {
        if (id < 1) return Result.Failure<AdminUpdateMyResumeViewModel>(ErrorMessages.SomethingWentWrong);

        var item = await myResumeRepository.FirstOrDefaultAsync(s => s.Id == id);

        if (item is null) return Result.Failure<AdminUpdateMyResumeViewModel>(ErrorMessages.NotFoundError);

        var result = item.MapToAdminUpdateMyResumeViewModel();

        return result;
    }

    #endregion

    #region UpdateAsync

    public async Task<Result> UpdateAsync(AdminUpdateMyResumeViewModel viewModel)
    {
        if (viewModel.Id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);

        if (viewModel.DisplayPriority < 1)
            return Result.Failure(string.Format(ErrorMessages.NotValid, "Display Priority"));
        
        if (await myResumeRepository.AnyAsync(x => x.DisplayPriority == viewModel.DisplayPriority  && x.ResumeType == viewModel.ResumeType && !x.IsDeleted && x.Id != viewModel.Id))
            return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        
        var item = await myResumeRepository.FirstOrDefaultAsync(s => s.Id == viewModel.Id);

        if (item is null) return Result.Failure(ErrorMessages.NotFoundError);

        viewModel.MapToMyResume(item);

        myResumeRepository.Update(item);
        await myResumeRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.UpdateSuccessfullyDone);
    }

    #endregion

    #region DeleteOrRecoverAsync

    public async Task<Result> DeleteOrRecoverAsync(short id)
    {
        if (id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);

        var item = await myResumeRepository.GetByIdAsync(id);

        if (item is null) return Result.Failure(ErrorMessages.NotFoundError);
        
        if (item.IsDeleted)
        {
            var hasDuplicate = await myResumeRepository.AnyAsync(x =>
                x.DisplayPriority == item.DisplayPriority  && x.ResumeType == item.ResumeType && !x.IsDeleted);

            if (hasDuplicate)
                return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        }
        
        myResumeRepository.SoftDeleteOrRecover(item);
        await myResumeRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.SuccessfullyDone);
    }

    #endregion

    #endregion

    #region Client

    #region FilterAsync

    public async Task<ClientFilterMyResumeViewModel> FilterAsync(ClientFilterMyResumeViewModel filter)
    {
        #region Filter

        filter ??= new();

        var conditions = Filter.GenerateConditions<MyResume>();
        var orders = Filter.GenerateOrders<MyResume>();

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
        
        switch (filter.ResumeType)
        {
            case FilterMyResumeType.None:
                conditions.Add(s => s.ResumeType == MyResumeType.None);
                break;
            case FilterMyResumeType.Education:
                conditions.Add(s => s.ResumeType == MyResumeType.Education);
                break;
            case FilterMyResumeType.Experience:
                conditions.Add(s => s.ResumeType == MyResumeType.Experience);
                break;
            case FilterMyResumeType.Courses:
                conditions.Add(s => s.ResumeType == MyResumeType.Courses);
                break;
        }

        #endregion

        await myResumeRepository.FilterAsync(filter, conditions, s => s.MapToClientMyResumeViewModel(),orders);
        return filter;
    }

#endregion

    #endregion
}