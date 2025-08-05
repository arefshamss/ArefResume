using Aref.Application.Extensions;
using Aref.Application.Mappers.MyInfoMappings;
using Aref.Application.Services.Interfaces;
using Aref.Application.Statics;
using Aref.Domain.Contracts;
using Aref.Domain.Enums.Common;
using Aref.Domain.Models.MyInfo;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.MyInfo.Admin;
using Microsoft.EntityFrameworkCore;

namespace Aref.Application.Services.Implementations;

public class MyInfoService(
    IMyInfoRepository myInfoRepository) : IMyInfoService
{
    #region Admin

    #region FillModelForUpdateAsync

    public async Task<Result<AdminUpdateMyInfoViewModel>> FillModelForUpdateAsync(short id)
    {
        if (id < 1)
            return Result.Failure<AdminUpdateMyInfoViewModel>(ErrorMessages.SomethingWentWrong);
        
        var info = await myInfoRepository.FirstOrDefaultAsync(s => s.Id == id);

        if (info is null)
            return Result.Failure<AdminUpdateMyInfoViewModel>(ErrorMessages.NotFoundError);

        var result = info.MapToAdminUpdateMyInfoViewModel();

        return result;
    }

    #endregion

    #region UpdateAsync

    public async Task<Result> UpdateAsync(AdminUpdateMyInfoViewModel viewModel)
    {
        if (viewModel.Id < 1) return Result.Failure(ErrorMessages.SomethingWentWrong);

        var info = await myInfoRepository.FirstOrDefaultAsync(s => s.Id == viewModel.Id);

        if (info is null) return Result.Failure(ErrorMessages.NotFoundError);

        if (viewModel.Image is not null)
        {
            var extension = Path.GetExtension(viewModel.Image.FileName);
            // var fileName = $"Aref-Shamspour{extension}";
            var fileName = $"Aref-Shamspour";
            
            var result = await viewModel.Image.AddImageToServer(FilePaths.MyInfoImagePath, deleteFileName: info.ImageUrl, suggestedFileName:fileName);

            if (result.IsFailure) return Result.Failure(result.Message!);

            info.ImageUrl = result.Value;
        }
        
        if (viewModel.Cv is not null)
        {
            var extension = Path.GetExtension(viewModel.Cv.FileName);
            var fileName = $"Aref-Shamspour-CV{extension}";
            
            var result = await viewModel.Cv.AddFilesToServer(fileName, FilePaths.MyInfoFilePath);

            if (result.IsFailure) return Result.Failure(result.Message!);

            info.CvUrl = result.Value;
        }
        

        viewModel.MapToMyInfo(info);

        myInfoRepository.Update(info);
        await myInfoRepository.SaveChangesAsync();

        return Result.Success(SuccessMessages.UpdateSuccessfullyDone);
    }

    #endregion

    #endregion
}