using Aref.Application.Services.Interfaces;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.CounterBox.Admin;
using Aref.Infra.Data.Statics;
using Aref.Web.Areas.Admin.Controllers.Common;
using Aref.Web.Attributes;
using Aref.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Controllers;

[InvokePermission(PermissionsName.CounterBoxManagement)]
public class CounterBoxController(
    ICounterBoxService counterBoxService) : AdminBaseController
{
    #region List

    [HttpGet]
    [InvokePermission(PermissionsName.CounterBoxList)]
    public async Task<IActionResult> List(AdminFilterCounterBoxViewModel filter)
    {
        var result = await counterBoxService.FilterAsync(filter);
        return AjaxSubstitutionResult(filter, result);
    }

    #endregion

    #region Create

    [HttpGet]
    [InvokePermission(PermissionsName.CreateCounterBox)]
    public IActionResult Create() =>
        PartialView("_CreatePartial", new AdminCreateCounterBoxViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    [InvokePermission(PermissionsName.CreateCounterBox)]
    public async Task<IActionResult> Create(AdminCreateCounterBoxViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ErrorMessages.ModelStateNotValid);

        var result = await counterBoxService.CreateAsync(viewModel);

        return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
    }

    #endregion

    #region Update

    [InvokePermission(PermissionsName.UpdateCounterBox)]
    public async Task<IActionResult> Update(short id)
    {
        var result = await counterBoxService.FillModelForUpdateAsync(id);

        return result.IsSuccess ? PartialView("_UpdatePartial", result.Value) : BadRequest(result.Message);
    }

    [InvokePermission(PermissionsName.UpdateCounterBox)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(AdminUpdateCounterBoxViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ErrorMessages.ModelStateNotValid);
        
        var result = await counterBoxService.UpdateAsync(viewModel);

        return result.IsSuccess ? Ok(result.Message) : BadRequest(result.Message);
    }

    #endregion

    #region DeleteOrRecover

    [InvokePermission(PermissionsName.DeleteOrRecoverCounterBox)]
    public async Task<IActionResult> DeleteOrRecover(short id)
    {
        var result = await counterBoxService.DeleteOrRecoverAsync(id);

        return result.IsFailure ? BadRequest(result.Message) : Ok(result.Message);
    }

    #endregion
}