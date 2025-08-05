using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.MyProject.Admin;
using Aref.Infra.Data.Statics;
using Aref.Web.Areas.Admin.Controllers.Common;
using Aref.Web.Attributes;
using Aref.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Controllers;



[InvokePermission(PermissionsName.MyProjectManagement)]
public class MyProjectController(
    IMyProjectService myProjectService) : AdminBaseController
{
    #region List

    [InvokePermission(PermissionsName.MyProjectList)]
    public async Task<IActionResult> List(AdminFilterMyProjectViewModel filter)
    {
        var result = await myProjectService.FilterAsync(filter);
        return View(result);
    }

    #endregion

    #region Create

    [InvokePermission(PermissionsName.CreateMyProject)]
    public IActionResult Create()
    {
        var model = new AdminCreateMyProjectViewModel();
        return View(model);
    }

    [InvokePermission(PermissionsName.CreateMyProject)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AdminCreateMyProjectViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ModelState.GetModelErrorsAsString());
            return View(viewModel);
        }

        var result = await myProjectService.CreateAsync(viewModel);

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

    [InvokePermission(PermissionsName.UpdateMyProject)]
    public async Task<IActionResult> Update(short id)
    {
        var result = await myProjectService.FillModelForUpdateAsync(id);

        if (result.IsFailure)
        {
            ShowToasterErrorMessage(result.Message);
            return View(nameof(List));
        }

        return View(result.Value);
    }

    [InvokePermission(PermissionsName.UpdateMyProject)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(AdminUpdateMyProjectViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ModelState.GetModelErrorsAsString());
            return View(viewModel);
        }

        var result = await myProjectService.UpdateAsync(viewModel);

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

    [InvokePermission(PermissionsName.DeleteOrRecoverMyProject)]
    public async Task<IActionResult> DeleteOrRecover(short id)
    {
        var result = await myProjectService.DeleteOrRecoverAsync(id);

        return result.IsFailure ? BadRequest(result.Message) : Ok(result.Message);
    }

    #endregion
}