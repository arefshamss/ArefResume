using Aref.Domain.Models.MySkill;
using Aref.Domain.ViewModels.MySkill.Admin;
using Aref.Domain.ViewModels.MySkill.Client;

namespace Aref.Application.Mappers.MySkillMappings;

public static class MySkillMapper
{
    #region Admin

    public static AdminMySkillViewModel MapToAdminMySkillViewModel(this MySkill model) => new()
    {
        Id = model.Id,
        IsDeleted = model.IsDeleted,
        Title = model.Title,
        ImageUrl = model.ImageUrl,
        Percent = model.Percent,
        DisplayPriority = model.DisplayPriority,
    };

    public static MySkill MapToMySkill(this AdminCreateMySkillViewModel viewModel) => new()
    {
        Title = viewModel.Title,
        SubTitle = viewModel.SubTitle,
        Percent = viewModel.Percent,
        DisplayPriority = viewModel.DisplayPriority,
    };

    public static AdminUpdateMySkillViewModel MapToAdminUpdateMySkillViewModel(this MySkill model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        SubTitle = model.SubTitle,
        ImageUrl = model.ImageUrl,
        Percent = model.Percent,
        DisplayPriority = model.DisplayPriority,
    };

    public static void MapToMySkill(this AdminUpdateMySkillViewModel viewModel, MySkill model)
    {
        model.Title = viewModel.Title;
        model.SubTitle = viewModel.SubTitle;
        model.Percent = viewModel.Percent;
        model.DisplayPriority = viewModel.DisplayPriority;
    }

    #endregion

    #region Client

    public static ClientMySkillViewModel MapToClientMySkillViewModel(this MySkill model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        SubTitle = model.SubTitle,
        ImageUrl = model.ImageUrl,
        Percent = model.Percent,
        DisplayPriority = model.DisplayPriority,
    };

    #endregion
}