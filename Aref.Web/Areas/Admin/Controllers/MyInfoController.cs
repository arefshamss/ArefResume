using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.MyInfo.Admin;
using Aref.Infra.Data.Statics;
using Aref.Web.Areas.Admin.Controllers.Common;
using Aref.Web.Attributes;
using Aref.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Controllers;

[InvokePermission(PermissionsName.MyInfoManagement)]
public class MyInfoController(
    IMyInfoService myInfoService) : AdminBaseController
{
    #region Update
    
    [InvokePermission(PermissionsName.UpdateMyInfo)]
    public async Task<IActionResult> Update()
    {
        var result = await myInfoService.FillModelForUpdateAsync(1);

        if (result.IsFailure)
        {
            ShowToasterErrorMessage(result.Message);
            return View(nameof(Update));
        }

        return View(result.Value);
    }

    [InvokePermission(PermissionsName.UpdateMyInfo)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(AdminUpdateMyInfoViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ModelState.GetModelErrorsAsString());
            return View(viewModel);
        }

        var result = await myInfoService.UpdateAsync(viewModel);

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