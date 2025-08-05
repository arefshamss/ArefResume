using Aref.Domain.Models.MyResume;
using Aref.Domain.ViewModels.MyResume.Admin;
using Aref.Domain.ViewModels.MyResume.Client;

namespace Aref.Application.Mappers.MyResumeMappings;

public static class MyResumeMepper
{
    #region Admin

    public static AdminMyResumeViewModel MapToAdminMyResumeViewModel(this MyResume model) => new()
    {
        Id = model.Id,
        IsDeleted = model.IsDeleted,
        Title = model.Title,
        Years = model.Years,
        Description = model.Description,
        ResumeType = model.ResumeType,
        DisplayPriority = model.DisplayPriority
    };

    public static MyResume MapToMyResume(this AdminCreateMyResumeViewModel viewModel) => new()
    {
        Title = viewModel.Title,
        Years = viewModel.Years,
        Description = viewModel.Description,
        ResumeType = viewModel.ResumeType,
        DisplayPriority = viewModel.DisplayPriority
    };

    public static AdminUpdateMyResumeViewModel MapToAdminUpdateMyResumeViewModel(this MyResume model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        Years = model.Years,
        Description = model.Description,
        ResumeType = model.ResumeType,
        DisplayPriority = model.DisplayPriority
    };

    public static void MapToMyResume(this AdminUpdateMyResumeViewModel viewModel, MyResume model)
    {
        model.Title = viewModel.Title;
        model.Years = viewModel.Years;
        model.Description = viewModel.Description;
        model.ResumeType = viewModel.ResumeType;
        model.DisplayPriority = viewModel.DisplayPriority;
    }

    #endregion

    #region Client

    public static ClientMyResumeViewModel MapToClientMyResumeViewModel(this MyResume model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        Years = model.Years,
        Description = model.Description,
        IsDeleted = model.IsDeleted,
        ResumeType = model.ResumeType,
        DisplayPriority = model.DisplayPriority
    };

    #endregion
}