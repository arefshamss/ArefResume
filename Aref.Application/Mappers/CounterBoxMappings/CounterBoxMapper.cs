using Aref.Domain.Models.CounterBox;
using Aref.Domain.ViewModels.CounterBox.Admin;
using Aref.Domain.ViewModels.CounterBox.Client;

namespace Aref.Application.Mappers.CounterBoxMappings;

public static class CounterBoxMapper
{
    #region Admin

    public static AdminCounterBoxViewModel MapToAdminCounterBoxViewModel(this CounterBox model) => new()
    {
        Id = model.Id,
        IsDeleted = model.IsDeleted,
        Title = model.Title,
        Count = model.Count,
        DisplayPriority = model.DisplayPriority,
    };

    public static CounterBox MapToCounterBox(this AdminCreateCounterBoxViewModel viewModel) => new()
    {
        Title = viewModel.Title,
        Count = viewModel.Count,
        DisplayPriority = viewModel.DisplayPriority,
    };

    public static AdminUpdateCounterBoxViewModel MapToAdminUpdateCounterBoxViewModel(this CounterBox model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        Count = model.Count,
        DisplayPriority = model.DisplayPriority,
    };

    public static void MapToCounterBox(this AdminUpdateCounterBoxViewModel viewModel, CounterBox model)
    {
        model.Title = viewModel.Title;
        model.Count = viewModel.Count;
        model.DisplayPriority = viewModel.DisplayPriority;
    }

    #endregion

    #region Client

    public static ClientCounterBoxViewModel MapToClientCounterBoxViewModel(this CounterBox model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        Count = model.Count,
        DisplayPriority = model.DisplayPriority,
    };

    #endregion
}