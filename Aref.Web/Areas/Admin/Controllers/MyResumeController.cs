using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.MyResume.Admin;
using Aref.Infra.Data.Statics;
using Aref.Web.Areas.Admin.Controllers.Common;
using Aref.Web.Attributes;
using Aref.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Controllers;

[InvokePermission(PermissionsName.MyResumeManagement)]
public class MyResumeController(
    IMyResumeService myResumeService) : AdminBaseController
{
    #region List

    [InvokePermission(PermissionsName.MyResumeList)]
    public async Task<IActionResult> List(AdminFilterMyResumeViewModel filter)
    {
        var result = await myResumeService.FilterAsync(filter);
        return View(result);
    }

    #endregion

    #region Create

    [InvokePermission(PermissionsName.CreateMyResume)]
    public IActionResult Create()
    {
        var model = new AdminCreateMyResumeViewModel();
        return View(model);
    }

    [InvokePermission(PermissionsName.CreateMyResume)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AdminCreateMyResumeViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ModelState.GetModelErrorsAsString());
            return View(viewModel);
        }

        var result = await myResumeService.CreateAsync(viewModel);

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
    
    [InvokePermission(PermissionsName.UpdateMyResume)]
    public async Task<IActionResult> Update(short id)
    {
        var result = await myResumeService.FillModelForUpdateAsync(id);

        if (result.IsFailure)
        {
            ShowToasterErrorMessage(result.Message);
            return View(nameof(List));
        }

        return View(result.Value);
    }

    [InvokePermission(PermissionsName.UpdateMyResume)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(AdminUpdateMyResumeViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ModelState.GetModelErrorsAsString());
            return View(viewModel);
        }

        var result = await myResumeService.UpdateAsync(viewModel);

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

    [InvokePermission(PermissionsName.DeleteOrRecoverMyResume)]
    public async Task<IActionResult> DeleteOrRecover(short id)
    {
        var result = await myResumeService.DeleteOrRecoverAsync(id);

        return result.IsFailure ? BadRequest(result.Message) : Ok(result.Message);
    }

    #endregion
}