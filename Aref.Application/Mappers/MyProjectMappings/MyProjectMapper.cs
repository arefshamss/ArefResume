using Aref.Application.Extensions;
using Aref.Domain.Models.MyProject;
using Aref.Domain.ViewModels.MyProject.Admin;
using Aref.Domain.ViewModels.MyProject.Client;

namespace Aref.Application.Mappers.MyProjectMappings;

public static class MyProjectMapper
{
    #region Admin

    public static AdminMyProjectViewModel MapToAdminMyProjectViewModel(this MyProject model) => new()
    {
        Id = model.Id,
        IsDeleted = model.IsDeleted,
        Title = model.Title,
        Link = model.Link.NormalizeSiteUrl(),
        SecondLink = model.SecondLink.NormalizeSiteUrl(),
        Developer = model.Developer,
        DisplayPriority = model.DisplayPriority,
    };

    public static MyProject MapToMyProject(this AdminCreateMyProjectViewModel viewModel) => new()
    {
        Title = viewModel.Title,
        Link = viewModel.Link.NormalizeSiteUrl(),
        SecondLink = viewModel.SecondLink.NormalizeSiteUrl(),
        LinkButtonTitle = viewModel.LinkButtonTitle,
        SecondLinkButtonTitle = viewModel.SecondLinkButtonTitle,
        Developer = viewModel.Developer,
        DisplayPriority = viewModel.DisplayPriority,
    };

    public static AdminUpdateMyProjectViewModel MapToAdminUpdateMyProjectViewModel(this MyProject model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        Link = model.Link.NormalizeSiteUrl(),
        SecondLink = model.SecondLink.NormalizeSiteUrl(),
        LinkButtonTitle = model.LinkButtonTitle,
        SecondLinkButtonTitle = model.SecondLinkButtonTitle,
        Developer = model.Developer,
        ImageUrl = model.ImageUrl,
        DisplayPriority = model.DisplayPriority,
    };

    public static void MapToMyProject(this AdminUpdateMyProjectViewModel viewModel, MyProject model)
    {
        model.Title = viewModel.Title;
        model.Link = viewModel.Link.NormalizeSiteUrl();
        model.SecondLink = viewModel.SecondLink.NormalizeSiteUrl();
        model.LinkButtonTitle = viewModel.LinkButtonTitle;
        model.SecondLinkButtonTitle = viewModel.SecondLinkButtonTitle;
        model.Developer = viewModel.Developer;
        model.DisplayPriority = viewModel.DisplayPriority;
    }

    #endregion

    #region Client

    public static ClientMyProjectViewModel MapToClientMyProjectViewModel(this MyProject model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        Link = model.Link,
        SecondLink = model.SecondLink.NormalizeSiteUrl(),
        LinkButtonTitle = model.LinkButtonTitle,
        SecondLinkButtonTitle = model.SecondLinkButtonTitle,
        Developer = model.Developer,
        ImageUrl = model.ImageUrl,
        DisplayPriority = model.DisplayPriority
    };

    #endregion
}