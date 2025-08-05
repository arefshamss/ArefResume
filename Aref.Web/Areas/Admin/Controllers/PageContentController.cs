using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.PageContent.Admin;
using Aref.Infra.Data.Statics;
using Aref.Web.Areas.Admin.Controllers.Common;
using Aref.Web.Attributes;
using Aref.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Controllers;

[InvokePermission(PermissionsName.PageContentManagement)]
public class PageContentController(
    IPageContentService pageContentService) : AdminBaseController
{
    #region Update
    
    [InvokePermission(PermissionsName.UpdatePageContent)]
    public async Task<IActionResult> Update(short id)
    {
        var result = await pageContentService.FillModelForUpdateAsync(id);

        if (result.IsFailure)
        {
            ShowToasterErrorMessage(result.Message);
            return View(nameof(Update));
        }

        return View(result.Value);
    }

    [InvokePermission(PermissionsName.UpdatePageContent)]
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(AdminUpdatePageContentViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ModelState.GetModelErrorsAsString());
            return View(viewModel);
        }

        var result = await pageContentService.UpdateAsync(viewModel);

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