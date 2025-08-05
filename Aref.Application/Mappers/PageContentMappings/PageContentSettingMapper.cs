using Aref.Domain.Models.PageContent;
using Aref.Domain.ViewModels.PageContentSetting.Admin;

namespace Aref.Application.Mappers.PageContentMappings;

public static class PageContentSettingMapper
{
    #region Admin
    
    public static AdminUpdatePageContentSettingViewModel MapToAdminUpdatePageContentSettingViewModel(this PageContentSetting model) => new()
    {
        Id = model.Id,
        AboutMeVisibility = model.AboutMeVisibility,
        MyResumeVisibility = model.MyResumeVisibility,
        MySkillVisibility = model.MySkillVisibility,
        MyProjectVisibility = model.MyProjectVisibility,
        ContactMeVisibility = model.ContactMeVisibility,
    };

    public static void MapToPageContentSetting(this AdminUpdatePageContentSettingViewModel viewModel, PageContentSetting model)
    {
        model.AboutMeVisibility = viewModel.AboutMeVisibility;
        model.MyResumeVisibility = viewModel.MyResumeVisibility;
        model.MySkillVisibility = viewModel.MySkillVisibility;
        model.MyProjectVisibility = viewModel.MyProjectVisibility;
        model.ContactMeVisibility = viewModel.ContactMeVisibility;
    }

    #endregion
}