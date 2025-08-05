using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.MyService.Admin;
using Aref.Infra.Data.Statics;
using Aref.Web.Areas.Admin.Controllers.Common;
using Aref.Web.Attributes;
using Aref.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Aref.Web.Areas.Admin.Controllers;

[InvokePermission(PermissionsName.MyServiceManagement)]
public class MyServiceController(
    IMyServiceService myServiceService) : AdminBaseController
{
    #region List

    [InvokePermission(PermissionsName.MyServiceList)]
    public async Task<IActionResult> List(AdminFilterMyServiceViewModel filter)
    {
        var result = await myServiceService.FilterAsync(filter);
        return View(result);
    }

    #endregion

    #region Create

    [InvokePermission(PermissionsName.CreateMyService)]
    public IActionResult Create()
    {
        var model = new AdminCreateMyServiceViewModel();
        return View(model);
    }

    [InvokePermission(PermissionsName.CreateMyService)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AdminCreateMyServiceViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ModelState.GetModelErrorsAsString());
            return View(viewModel);
        }

        var result = await myServiceService.CreateAsync(viewModel);

        if (result.IsFailure)
        {
            ShowToasterErrorMessage(result.Message);
            return View(viewModel);
        }

        ShowToasterSuccessMessage(result.Message);
        return RedirectToAction(nameof(List));
    }

    #endregion

    #region Update
    
    [InvokePermission(PermissionsName.UpdateMyService)]
    public async Task<IActionResult> Update(short id)
    {
        var result = await myServiceService.FillModelForUpdateAsync(id);

        if (result.IsFailure)
        {
            ShowToasterErrorMessage(result.Message);
            return View(nameof(List));
        }

        return View(result.Value);
    }

    [InvokePermission(PermissionsName.UpdateMyService)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(AdminUpdateMyServiceViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ModelState.GetModelErrorsAsString());
            return View(viewModel);
        }

        var result = await myServiceService.UpdateAsync(viewModel);

        if (result.IsFailure)
        {
            ShowToasterErrorMessage(result.Message);
            return View(viewModel);
        }

        ShowToasterSuccessMessage(result.Message);
        return RedirectToAction(nameof(List));
    }

    #endregion

    #region DeleteOrRecover

    [InvokePermission(PermissionsName.DeleteOrRecoverMyService)]
    public async Task<IActionResult> DeleteOrRecover(short id)
    {
        var result = await myServiceService.DeleteOrRecoverAsync(id);

        return result.IsFailure ? BadRequest(result.Message) : Ok(result.Message);
    }

    #endregion
}