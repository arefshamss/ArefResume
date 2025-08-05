using Aref.Application.Services.Interfaces;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.ContactMe.Client;
using Aref.Web.Controllers.Common;
using Aref.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Controllers;


public class ContactMeController(
    IContactMeService contactMeService) : SiteBaseController
{
    [HttpPost]
    public async Task<IActionResult> Contact(ClientCreateContactMeViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return Json(new
            {
                success = false,
                message = ModelState.GetModelErrorsAsString()
            });
        }

        var result = await contactMeService.CreateAsync(viewModel);

        return Json(new
        {
            success = result.IsSuccess,
            message = result.Message
        });
    }

}