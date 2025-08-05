using Aref.Application.Extensions;
using Aref.Domain.Models.SocialMedia;
using Aref.Domain.ViewModels.SocialMedia.Admin;
using Aref.Domain.ViewModels.SocialMedia.Client;

namespace Aref.Application.Mappers.SocialMediaMappings;

public static class SocialMediaMapper
{
    #region Admin

    public static AdminSocialMediaViewModel MapToAdminSocialMediaViewModel(this SocialMedia model) => new()
    {
        Id = model.Id,
        IsDeleted = model.IsDeleted,
        Title = model.Title,
        Link = model.Link.NormalizeSiteUrl(),
        IsVisible = model.IsVisible,
        DisplayPriority = model.DisplayPriority,
    };

    public static SocialMedia MapToSocialMedia(this AdminCreateSocialMediaViewModel viewModel) => new()
    {
        Title = viewModel.Title,
        IsVisible = viewModel.IsVisible,
        Link = viewModel.Link.NormalizeSiteUrl(),
        DisplayPriority = viewModel.DisplayPriority,
    };

    public static AdminUpdateSocialMediaViewModel MapToAdminUpdateSocialMediaViewModel(this SocialMedia model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        IsVisible = model.IsVisible,
        IconName = model.IconName,
        Link = model.Link.NormalizeSiteUrl(),
        DisplayPriority = model.DisplayPriority,
    };

    public static void MapToSocialMedia(this AdminUpdateSocialMediaViewModel viewModel, SocialMedia model)
    {
        model.Title = viewModel.Title;
        model.IsVisible = viewModel.IsVisible;
        model.Link = viewModel.Link.NormalizeSiteUrl();
        model.DisplayPriority = viewModel.DisplayPriority;
    }

    #endregion

    #region Client

    public static ClientSocialMediaViewModel MapToClientSocialMediaViewModel(this SocialMedia model) => new()
    {
        Id = model.Id,
        Title = model.Title,
        IsVisible = model.IsVisible,
        IconName = model.IconName,
        Link = model.Link,
        DisplayPriority = model.DisplayPriority,
    };

    #endregion
}