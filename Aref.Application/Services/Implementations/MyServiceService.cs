using Aref.Application.Extensions;
using Aref.Application.Mappers.MyServiceMappings;
using Aref.Application.Services.Interfaces;
using Aref.Application.Statics;
using Aref.Domain.Contracts;
using Aref.Domain.Enums.Common;
using Aref.Domain.Models.MyService;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.MyService.Admin;
using Aref.Domain.ViewModels.MyService.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Aref.Application.Services.Implementations;

public class MyServiceService(
    IMyServiceRepository myServiceRepository) : IMyServiceService
{
    #region Admin

    #region FilterAsync

    public async Task<AdminFilterMyServiceViewModel> FilterAsync(AdminFilterMyServiceViewModel filter)
    {
        #region Filter

        filter ??= new();

        var conditions = Filter.GenerateConditions<MyService>();
        var orders = Filter.GenerateOrders<MyService>();

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

        await myServiceRepository.FilterAsync(filter, conditions, s => s.MapToAdminMyServiceViewModel(),orders);
        return filter;
    }

    #endregion

    #region CreateAsync

    public async Task<Result> CreateAsync(AdminCreateMyServiceViewModel viewModel)
    {       
        if (viewModel.DisplayPriority < 1)
            return Result.Failure(string.Format(ErrorMessages.NotValid, "Display Priority"));
        
        if (await myServiceRepository.AnyAsync(x => x.DisplayPriority == viewModel.DisplayPriority && !x.IsDeleted))
            return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        
        var service = viewModel.MapToMyService();

        #region AddImage

        var result = await viewModel.Icon.AddImageToServer(FilePaths.MyServiceIconPath, suggestedFileName: viewModel.Title);

        if (result.IsFailure) return Result.Failure(result.Message!);

        service.IconName = result.Value;

        #endregion

        await myServiceRepository.InsertAsync(service);
        await myServiceRepository.SaveChangesAsync();
        
        return Result.Success(SuccessMessages.InsertSuccessfullyDone);
    }

    #endregion

    #region FillModelForUpdateAsync

    public async Task<Result<AdminUpdateMyServiceViewModel>> FillModelForUpdateAsync(short id)
    {
        if (id < 1)
            return Result.Failure<AdminUpdateMyServiceViewModel>(ErrorMessages.SomethingWentWrong);

        var service = await myServiceRepository.FirstOrDefaultAsync(s => s.Id == id);

        if (service is null)
            return Result.Failure<AdminUpdateMyServiceViewModel>(ErrorMessages.NotFoundError);

        var result = service.MapToAdminUpdateMyServiceViewModel();

        return result;
    }

    #endregion

    #region UpdateAsync

    public async Task<Result> UpdateAsync(AdminUpdateMyServiceViewModel viewModel)
    {
        if (viewModel.Id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);
        
        if (viewModel.DisplayPriority < 1)
            return Result.Failure(string.Format(ErrorMessages.NotValid, "Display Priority"));
        
        if (await myServiceRepository.AnyAsync(x => x.DisplayPriority == viewModel.DisplayPriority && !x.IsDeleted && x.Id != viewModel.Id))
            return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));

        var service = await myServiceRepository.FirstOrDefaultAsync(s => s.Id == viewModel.Id);

        if (service is null) return Result.Failure(ErrorMessages.NotFoundError);

        if (viewModel.Icon is not null)
        {
            var result = await viewModel.Icon.AddImageToServer(FilePaths.MyServiceIconPath, deleteFileName: service.IconName);

            if (result.IsFailure) return Result.Failure(result.Message!);

            service.IconName = result.Value;
        }

        viewModel.MapToMyService(service);

        myServiceRepository.Update(service);
        await myServiceRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.UpdateSuccessfullyDone);
    }

    #endregion

    #region DeleteOrRecoverAsync

    public async Task<Result> DeleteOrRecoverAsync(short id)
    {
        if (id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);

        var service = await myServiceRepository.GetByIdAsync(id);

        if (service is null) return Result.Failure(ErrorMessages.NotFoundError);
        
        if (service.IsDeleted)
        {
            var hasDuplicate = await myServiceRepository.AnyAsync(x =>
                x.DisplayPriority == service.DisplayPriority && !x.IsDeleted);

            if (hasDuplicate)
                return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        }

        myServiceRepository.SoftDeleteOrRecover(service);
        await myServiceRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.SuccessfullyDone);
    }

    #endregion

    #endregion

    #region Client

    #region FilterAsync

    public async Task<ClientFilterMyServiceViewModel> FilterAsync(ClientFilterMyServiceViewModel filter)
    {
        #region Filter

        filter ??= new();

        var conditions = Filter.GenerateConditions<MyService>();
        var orders = Filter.GenerateOrders<MyService>();

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

        await myServiceRepository.FilterAsync(filter, conditions, s => s.MapToClientServiceViewModel(),orders);
        return filter;
    }

#endregion

    #endregion
}