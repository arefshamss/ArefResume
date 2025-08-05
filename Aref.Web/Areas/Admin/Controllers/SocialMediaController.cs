using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.SocialMedia.Admin;
using Aref.Infra.Data.Statics;
using Aref.Web.Areas.Admin.Controllers.Common;
using Aref.Web.Attributes;
using Aref.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Controllers;

[InvokePermission(PermissionsName.SocialMediaManagement)]
public class SocialMediaController(
    ISocialMediaService socialMediaService) : AdminBaseController
{
    #region List

    [InvokePermission(PermissionsName.SocialMediaList)]
    public async Task<IActionResult> List(AdminFilterSocialMediaViewModel filter)
    {
        var result = await socialMediaService.FilterAsync(filter);
        return View(result);
    }

    #endregion

    #region Create

    [InvokePermission(PermissionsName.CreateSocialMedia)]
    public IActionResult Create()
    {
        var model = new AdminCreateSocialMediaViewModel();
        return View(model);
    }

    [InvokePermission(PermissionsName.CreateSocialMedia)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AdminCreateSocialMediaViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ModelState.GetModelErrorsAsString());
            return View(viewModel);
        }

        var result = await socialMediaService.CreateAsync(viewModel);

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

    [InvokePermission(PermissionsName.UpdateSocialMedia)]
    public async Task<IActionResult> Update(short id)
    {
        var result = await socialMediaService.FillModelForUpdateAsync(id);

        if (result.IsFailure)
        {
            ShowToasterErrorMessage(result.Message);
            return View(nameof(List));
        }

        return View(result.Value);
    }

    [InvokePermission(PermissionsName.UpdateSocialMedia)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(AdminUpdateSocialMediaViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ModelState.GetModelErrorsAsString());
            return View(viewModel);
        }

        var result = await socialMediaService.UpdateAsync(viewModel);

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

    [InvokePermission(PermissionsName.DeleteOrRecoverSocialMedia)]
    public async Task<IActionResult> DeleteOrRecover(short id)
    {
        var result = await socialMediaService.DeleteOrRecoverAsync(id);

        return result.IsFailure ? BadRequest(result.Message) : Ok(result.Message);
    }

    #endregion
}