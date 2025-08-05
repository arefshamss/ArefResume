using System.Diagnostics.Metrics;
using Aref.Application.Mappers.CounterBoxMappings;
using Aref.Application.Services.Interfaces;
using Aref.Domain.Contracts;
using Aref.Domain.Enums.Common;
using Aref.Domain.Models.CounterBox;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.CounterBox.Admin;
using Aref.Domain.ViewModels.CounterBox.Client;
using Microsoft.EntityFrameworkCore;

namespace Aref.Application.Services.Implementations;

public class CounterBoxService(
    ICounterBoxRepository counterBoxRepository) : ICounterBoxService
{
    #region Admin

    #region FilterAsync

    public async Task<AdminFilterCounterBoxViewModel> FilterAsync(AdminFilterCounterBoxViewModel filter)
    {
        #region Filter

        filter ??= new();

        var conditions = Filter.GenerateConditions<CounterBox>();
        var orders = Filter.GenerateOrders<CounterBox>();

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

        await counterBoxRepository.FilterAsync(filter, conditions, s => s.MapToAdminCounterBoxViewModel(),orders);
        return filter;
    }

    #endregion

    #region CreateAsync

    public async Task<Result> CreateAsync(AdminCreateCounterBoxViewModel viewModel)
    {
        if (viewModel.DisplayPriority < 1)
            return Result.Failure(string.Format(ErrorMessages.NotValid, "Display Priority"));
        
        if (await counterBoxRepository.AnyAsync(x => x.DisplayPriority == viewModel.DisplayPriority && !x.IsDeleted))
            return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        
        var counter = viewModel.MapToCounterBox();

        await counterBoxRepository.InsertAsync(counter);
        await counterBoxRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.InsertSuccessfullyDone);
    }

    #endregion

    #region FillModelForUpdateAsync

    public async Task<Result<AdminUpdateCounterBoxViewModel>> FillModelForUpdateAsync(short id)
    {
        if (id < 1) return Result.Failure<AdminUpdateCounterBoxViewModel>(ErrorMessages.SomethingWentWrong);

        var counter = await counterBoxRepository.FirstOrDefaultAsync(s => s.Id == id);

        if (counter is null) return Result.Failure<AdminUpdateCounterBoxViewModel>(ErrorMessages.NotFoundError);

        var result = counter.MapToAdminUpdateCounterBoxViewModel();

        return result;
    }

    #endregion

    #region UpdateAsync

    public async Task<Result> UpdateAsync(AdminUpdateCounterBoxViewModel viewModel)
    {
        if (viewModel.Id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);
        
        if (viewModel.DisplayPriority < 1)
            return Result.Failure(string.Format(ErrorMessages.NotValid, "Display Priority"));
        
        if (await counterBoxRepository.AnyAsync(x => x.DisplayPriority == viewModel.DisplayPriority && !x.IsDeleted && x.Id != viewModel.Id))
            return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));

        var counter = await counterBoxRepository.FirstOrDefaultAsync(s => s.Id == viewModel.Id);

        if (counter is null) return Result.Failure(ErrorMessages.NotFoundError);

        viewModel.MapToCounterBox(counter);

        counterBoxRepository.Update(counter);
        await counterBoxRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.UpdateSuccessfullyDone);
    }

    #endregion

    #region DeleteOrRecoverAsync

    public async Task<Result> DeleteOrRecoverAsync(short id)
    {
        if (id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);
        
        var counter = await counterBoxRepository.GetByIdAsync(id);

        if (counter is null) return Result.Failure(ErrorMessages.NotFoundError);
        
        if (counter.IsDeleted)
        {
            var hasDuplicate = await counterBoxRepository.AnyAsync(x =>
                x.DisplayPriority == counter.DisplayPriority && !x.IsDeleted);

            if (hasDuplicate)
                return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        }

        counterBoxRepository.SoftDeleteOrRecover(counter);
        await counterBoxRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.SuccessfullyDone);
    }

    #endregion

    #endregion

    #region Client

    #region FilterAsync

    public async Task<ClientFilterCounterBoxViewModel> FilterAsync(ClientFilterCounterBoxViewModel filter)
    {
        #region Filter

        filter ??= new();

        var conditions = Filter.GenerateConditions<CounterBox>();
        var orders = Filter.GenerateOrders<CounterBox>();

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

        await counterBoxRepository.FilterAsync(filter, conditions, s => s.MapToClientCounterBoxViewModel(),orders);
        return filter;
    }

    #endregion

    #endregion
}