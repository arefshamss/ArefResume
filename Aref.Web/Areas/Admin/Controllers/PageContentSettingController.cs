using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.PageContentSetting.Admin;
using Aref.Infra.Data.Statics;
using Aref.Web.Areas.Admin.Controllers.Common;
using Aref.Web.Attributes;
using Aref.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Controllers;

[InvokePermission(PermissionsName.PageContentSettingManagement)]
public class PageContentSettingController(
    IPageContentSettingService pageContentSettingService) : AdminBaseController
{
    #region Update
    
    [InvokePermission(PermissionsName.UpdatePageContentSetting)]
    public async Task<IActionResult> Update()
    {
        var result = await pageContentSettingService.FillModelForUpdateAsync(1);

        if (result.IsFailure)
        {
            ShowToasterErrorMessage(result.Message);
            return RedirectToAction("index", "Home");
        }

        return View(result.Value);
    }

    [InvokePermission(PermissionsName.UpdatePageContentSetting)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(AdminUpdatePageContentSettingViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ModelState.GetModelErrorsAsString());
            return View(viewModel);
        }

        var result = await pageContentSettingService.UpdateAsync(viewModel);

        if (result.IsFailure)
        {
            ShowToasterErrorMessage(result.Message);
            return View(viewModel);
        }

        ShowToasterSuccessMessage(result.Message);
        return RedirectToAction(nameof(Update));
    }

    #endregion
}