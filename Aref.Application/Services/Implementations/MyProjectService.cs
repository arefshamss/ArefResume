using Aref.Application.Extensions;
using Aref.Application.Mappers.MyProjectMappings;
using Aref.Application.Services.Interfaces;
using Aref.Application.Statics;
using Aref.Domain.Contracts;
using Aref.Domain.Enums.Common;
using Aref.Domain.Models.MyProject;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.MyProject.Admin;
using Aref.Domain.ViewModels.MyProject.Client;
using Microsoft.EntityFrameworkCore;

namespace Aref.Application.Services.Implementations;

public class MyProjectService(
    IMyProjectRepository myProjectRepository) : IMyProjectService
{
    #region Admin

    #region FilterAsync

    public async Task<AdminFilterMyProjectViewModel> FilterAsync(AdminFilterMyProjectViewModel filter)
    {
        #region Filter

        filter ??= new();

        var conditions = Filter.GenerateConditions<MyProject>();
        var orders = Filter.GenerateOrders<MyProject>();

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

        await myProjectRepository.FilterAsync(filter, conditions, s => s.MapToAdminMyProjectViewModel(),orders);
        return filter;
    }

    #endregion

    #region CreateAsync

    public async Task<Result> CreateAsync(AdminCreateMyProjectViewModel viewModel)
    {
        if (viewModel.DisplayPriority < 1)
            return Result.Failure(string.Format(ErrorMessages.NotValid, "Display Priority"));
        
        if (await myProjectRepository.AnyAsync(x => x.DisplayPriority == viewModel.DisplayPriority && !x.IsDeleted))
            return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        
        var project = viewModel.MapToMyProject();

        #region AddImage

        var result = await viewModel.Image.AddImageToServer(FilePaths.MyProjectImagePath, suggestedFileName: viewModel.Title);

        if (result.IsFailure) return Result.Failure(result.Message!);

        project.ImageUrl = result.Value;

        #endregion

        await myProjectRepository.InsertAsync(project);
        await myProjectRepository.SaveChangesAsync();
        
        return Result.Success(SuccessMessages.InsertSuccessfullyDone);
    }

    #endregion

    #region FillModelForUpdateAsync

    public async Task<Result<AdminUpdateMyProjectViewModel>> FillModelForUpdateAsync(short id)
    {
        if (id < 1)
            return Result.Failure<AdminUpdateMyProjectViewModel>(ErrorMessages.SomethingWentWrong);

        var project = await myProjectRepository.FirstOrDefaultAsync(s => s.Id == id);

        if (project is null)
            return Result.Failure<AdminUpdateMyProjectViewModel>(ErrorMessages.NotFoundError);

        var result = project.MapToAdminUpdateMyProjectViewModel();

        return result;
    }

    #endregion

    #region UpdateAsync

    public async Task<Result> UpdateAsync(AdminUpdateMyProjectViewModel viewModel)
    {
        if (viewModel.Id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);
        
        if (viewModel.DisplayPriority < 1)
            return Result.Failure(string.Format(ErrorMessages.NotValid, "Display Priority"));
        
        if (await myProjectRepository.AnyAsync(x => x.DisplayPriority == viewModel.DisplayPriority && !x.IsDeleted && x.Id != viewModel.Id))
            return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        
        var project = await myProjectRepository.FirstOrDefaultAsync(s => s.Id == viewModel.Id);

        if (project is null) return Result.Failure(ErrorMessages.NotFoundError);

        if (viewModel.Image is not null)
        {
            var result = await viewModel.Image.AddImageToServer(FilePaths.MyProjectImagePath, deleteFileName: project.ImageUrl);

            if (result.IsFailure) return Result.Failure(result.Message!);

            project.ImageUrl = result.Value;
        }

        viewModel.MapToMyProject(project);

        myProjectRepository.Update(project);
        await myProjectRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.UpdateSuccessfullyDone);
    }

    #endregion

    #region DeleteOrRecoverAsync

    public async Task<Result> DeleteOrRecoverAsync(short id)
    {
        if (id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);

        var project = await myProjectRepository.GetByIdAsync(id);

        if (project is null) return Result.Failure(ErrorMessages.NotFoundError);

        if (project.IsDeleted)
        {
            var hasDuplicate = await myProjectRepository.AnyAsync(x =>
                x.DisplayPriority == project.DisplayPriority && !x.IsDeleted);

            if (hasDuplicate)
                return Result.Failure(string.Format(ErrorMessages.AlreadyExistError, "Display Priority"));
        }
        
        myProjectRepository.SoftDeleteOrRecover(project);
        await myProjectRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.SuccessfullyDone);
    }

    #endregion

    #endregion

    #region Client

    #region FilterAsync

    public async Task<ClientFilterMyProjectViewModel> FilterAsync(ClientFilterMyProjectViewModel filter)
    {
        #region Filter

        filter ??= new();

        var conditions = Filter.GenerateConditions<MyProject>();
        var orders = Filter.GenerateOrders<MyProject>();

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

        await myProjectRepository.FilterAsync(filter, conditions, s => s.MapToClientMyProjectViewModel(),orders);
        return filter;
    }

#endregion

    #endregion
}