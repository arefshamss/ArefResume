using Aref.Application.Extensions;
using Aref.Application.Mappers.MySkillMappings;
using Aref.Application.Services.Interfaces;
using Aref.Application.Statics;
using Aref.Domain.Contracts;
using Aref.Domain.Enums.Common;
using Aref.Domain.Models.MySkill;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.MySkill.Admin;
using Aref.Domain.ViewModels.MySkill.Client;
using Microsoft.EntityFrameworkCore;

namespace Aref.Application.Services.Implementations;

public class MySkillService(
    IMySkillRepository mySkillRepository) : IMySkillService
{
    #region Admin

    #region FilterAsync

    public async Task<AdminFilterMySkillViewModel> FilterAsync(AdminFilterMySkillViewModel filter)
    {
        #region Filter

        filter ??= new();

        var conditions = Filter.GenerateConditions<MySkill>();
        var orders = Filter.GenerateOrders<MySkill>();

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

        await mySkillRepository.FilterAsync(filter, conditions, s => s.MapToAdminMySkillViewModel(),orders);
        return filter;
    }

    #endregion

    #region CreateAsync

    public async Task<Result> CreateAsync(AdminCreateMySkillViewModel viewModel)
    {
        if (viewModel.DisplayPriority < 1)
            return Result.Failure(string.Format(ErrorMessages.NotValid, "Display Priority"));
        
        if (await mySkillRepository.AnyAsync(x => x.DisplayPriority == viewModel.DisplayPriority && !x.IsDeleted))
            return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        
        var skill = viewModel.MapToMySkill();

        #region AddImage

        var result = await viewModel.Image.AddImageToServer(FilePaths.MySkillImagePath, suggestedFileName: viewModel.Title);

        if (result.IsFailure) return Result.Failure(result.Message!);

        skill.ImageUrl = result.Value;

        #endregion

        await mySkillRepository.InsertAsync(skill);
        await mySkillRepository.SaveChangesAsync();
        
        return Result.Success(SuccessMessages.InsertSuccessfullyDone);
    }

    #endregion

    #region FillModelForUpdateAsync

    public async Task<Result<AdminUpdateMySkillViewModel>> FillModelForUpdateAsync(short id)
    {
        if (id < 1)
            return Result.Failure<AdminUpdateMySkillViewModel>(ErrorMessages.SomethingWentWrong);

        var skill = await mySkillRepository.FirstOrDefaultAsync(s => s.Id == id);

        if (skill is null)
            return Result.Failure<AdminUpdateMySkillViewModel>(ErrorMessages.NotFoundError);

        var result = skill.MapToAdminUpdateMySkillViewModel();

        return result;
    }

    #endregion

    #region UpdateAsync

    public async Task<Result> UpdateAsync(AdminUpdateMySkillViewModel viewModel)
    {
        if (viewModel.Id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);
        
        if (viewModel.DisplayPriority < 1)
            return Result.Failure(string.Format(ErrorMessages.NotValid, "Display Priority"));
        
        if (await mySkillRepository.AnyAsync(x => x.DisplayPriority == viewModel.DisplayPriority && !x.IsDeleted && x.Id != viewModel.Id))
            return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        
        var skill = await mySkillRepository.FirstOrDefaultAsync(s => s.Id == viewModel.Id);

        if (skill is null) return Result.Failure(ErrorMessages.NotFoundError);

        if (viewModel.Image is not null)
        {
            var result = await viewModel.Image.AddImageToServer(FilePaths.MySkillImagePath, deleteFileName: skill.ImageUrl);

            if (result.IsFailure) return Result.Failure(result.Message!);

            skill.ImageUrl = result.Value;
        }

        viewModel.MapToMySkill(skill);

        mySkillRepository.Update(skill);
        await mySkillRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.UpdateSuccessfullyDone);
    }

    #endregion

    #region DeleteOrRecoverAsync

    public async Task<Result> DeleteOrRecoverAsync(short id)
    {
        if (id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);

        var skill = await mySkillRepository.GetByIdAsync(id);

        if (skill is null) return Result.Failure(ErrorMessages.NotFoundError);
        
        if (skill.IsDeleted)
        {
            var hasDuplicate = await mySkillRepository.AnyAsync(x =>
                x.DisplayPriority == skill.DisplayPriority && !x.IsDeleted);

            if (hasDuplicate)
                return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        }
        
        mySkillRepository.SoftDeleteOrRecover(skill);
        await mySkillRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.SuccessfullyDone);
    }

    #endregion

    #endregion

    #region Client

    #region FilterAsync

    public async Task<ClientFilterMySkillViewModel> FilterAsync(ClientFilterMySkillViewModel filter)
    {
        #region Filter

        filter ??= new();

        var conditions = Filter.GenerateConditions<MySkill>();
        var orders = Filter.GenerateOrders<MySkill>();

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

        await mySkillRepository.FilterAsync(filter, conditions, s => s.MapToClientMySkillViewModel(),orders);
        return filter;
    }

#endregion

    #endregion
}