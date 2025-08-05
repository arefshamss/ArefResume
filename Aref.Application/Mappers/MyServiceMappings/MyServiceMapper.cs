using Aref.Domain.Models.MyService;
using Aref.Domain.ViewModels.MyService.Admin;
using Aref.Domain.ViewModels.MyService.Client;

namespace Aref.Application.Mappers.MyServiceMappings;

public static class MyServiceMapper
{
    #region Admin

    public static AdminMyServiceViewModel MapToAdminMyServiceViewModel(this MyService model) => new()
    {
        Id = model.Id,
        IsDeleted = model.IsDeleted,
        Title = model.Title,
        IconName = model.IconName,
        DisplayPriority = model.DisplayPriority,
    };

    public static MyService MapToMyService(this AdminCreateMyServiceViewModel viewModel) => new()
    {
        Title = viewModel.Title,
        Description = viewModel.Description,
        DisplayPriority = viewModel.DisplayPriority,
    };

    public static AdminUpdateMyServiceViewModel MapToAdminUpdateMyServiceViewModel(this MyService model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        Description = model.Description,
        IconName = model.IconName,
        DisplayPriority = model.DisplayPriority,
    };

    public static void MapToMyService(this AdminUpdateMyServiceViewModel viewModel, MyService model)
    {
        model.Title = viewModel.Title;
        model.Description = viewModel.Description;
        model.DisplayPriority = viewModel.DisplayPriority;
    }

    #endregion

    #region Client

    public static ClientMyServiceViewModel MapToClientServiceViewModel(this MyService model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        Description = model.Description,
        IconName = model.IconName,
        DisplayPriority = model.DisplayPriority,
    };

    #endregion
}