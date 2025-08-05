using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.ContactMe.Admin;
using Aref.Infra.Data.Statics;
using Aref.Web.Areas.Admin.Controllers.Common;
using Aref.Web.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Controllers;

[InvokePermission(PermissionsName.ContactMeManagement)]
public class ContactMeController(
    IContactMeService contactMeService) : AdminBaseController
{
    #region List

    [InvokePermission(PermissionsName.ContactMeList)]
    public async Task<IActionResult> List(AdminFilterContactMeViewModel filter)
    {
        var result = await contactMeService.FilterAsync(filter);
        return View(result);
    }

    #endregion

    #region Update

    [InvokePermission(PermissionsName.ContactMeDetails)]
    public async Task<IActionResult> Details(short id)
    {
        var result = await contactMeService.GetByIdAsync(id);

        if (result.IsFailure)
        {
            ShowToasterErrorMessage(result.Message);
            return View(nameof(List));
        }

        return View(result.Value);
    }

    #endregion

    #region DeleteOrRecover

    [InvokePermission(PermissionsName.DeleteOrRecoverContactMe)]
    public async Task<IActionResult> DeleteOrRecover(short id)
    {
        var result = await contactMeService.DeleteOrRecoverAsync(id);

        return result.IsFailure ? BadRequest(result.Message) : Ok(result.Message);
    }

    #endregion
}