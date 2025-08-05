using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.MySkill.Admin;
using Aref.Infra.Data.Statics;
using Aref.Web.Areas.Admin.Controllers.Common;
using Aref.Web.Attributes;
using Aref.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Controllers;

[InvokePermission(PermissionsName.MySkillManagement)]
public class MySkillController(
    IMySkillService mySkillService) : AdminBaseController
{
    #region List

    [InvokePermission(PermissionsName.MySkillList)]
    public async Task<IActionResult> List(AdminFilterMySkillViewModel filter)
    {
        var result = await mySkillService.FilterAsync(filter);
        return View(result);
    }

    #endregion

    #region Create

    [InvokePermission(PermissionsName.CreateMySkill)]
    public IActionResult Create()
    {
        var model = new AdminCreateMySkillViewModel();
        return View(model);
    }

    [InvokePermission(PermissionsName.CreateMySkill)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AdminCreateMySkillViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ModelState.GetModelErrorsAsString());
            return View(viewModel);
        }

        var result = await mySkillService.CreateAsync(viewModel);

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

    [InvokePermission(PermissionsName.UpdateMySkill)]
    public async Task<IActionResult> Update(short id)
    {
        var result = await mySkillService.FillModelForUpdateAsync(id);

        if (result.IsFailure)
        {
            ShowToasterErrorMessage(result.Message);
            return View(nameof(List));
        }

        return View(result.Value);
    }

    [InvokePermission(PermissionsName.UpdateMySkill)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(AdminUpdateMySkillViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ModelState.GetModelErrorsAsString());
            return View(viewModel);
        }

        var result = await mySkillService.UpdateAsync(viewModel);

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

    [InvokePermission(PermissionsName.DeleteOrRecoverMySkill)]
    public async Task<IActionResult> DeleteOrRecover(short id)
    {
        var result = await mySkillService.DeleteOrRecoverAsync(id);

        return result.IsFailure ? BadRequest(result.Message) : Ok(result.Message);
    }

    #endregion
}