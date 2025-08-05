using Aref.Domain.Enums.PageContent;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.PageContentSetting.Admin;

namespace Aref.Application.Services.Interfaces;

public interface IPageContentSettingService
{
    #region Admin
    Task<Result<AdminUpdatePageContentSettingViewModel>> FillModelForUpdateAsync(short id);

    Task<Result> UpdateAsync(AdminUpdatePageContentSettingViewModel viewModel);

    #endregion
}