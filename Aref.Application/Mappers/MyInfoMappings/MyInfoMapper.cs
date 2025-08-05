using Aref.Application.Extensions;
using Aref.Application.Statics;
using Aref.Domain.Models.MyInfo;
using Aref.Domain.ViewModels.MyInfo.Admin;

namespace Aref.Application.Mappers.MyInfoMappings;

public static class MyInfoMapper
{
    #region Admin

    public static AdminUpdateMyInfoViewModel MapToAdminUpdateMyInfoViewModel(this MyInfo model) => new()
    {
        Id = model.Id,
        FullName = model.FullName,
        Mobile = model.Mobile,
        Email = model.Email,
        Title = model.Title,
        ImageUrl = model.ImageUrl.IsNullOrEmptyOrWhiteSpace() ? FilePaths.CommonImagesPath + SiteTools.DefaultUserImageName : FilePaths.MyInfoImagePath + model.ImageUrl,
        CvUrl = model.CvUrl,
        MobileVisibility = model.MobileVisibility,
        EmailVisibility = model.EmailVisibility,
        CvVisibility = model.CvVisibility,
        TitleVisibility = model.TitleVisibility,
    };

    public static void MapToMyInfo(this AdminUpdateMyInfoViewModel viewModel, MyInfo model)
    {
        model.FullName = viewModel.FullName;
        model.Mobile = viewModel.Mobile;
        model.Email = viewModel.Email;
        model.Title = viewModel.Title;
        model.MobileVisibility = viewModel.MobileVisibility;
        model.EmailVisibility = viewModel.EmailVisibility;
        model.CvVisibility = viewModel.CvVisibility;
        model.TitleVisibility = viewModel.TitleVisibility;
    }

    #endregion
}