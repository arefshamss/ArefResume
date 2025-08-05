using Aref.Application.Extensions;
using Aref.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Components;

public class AdminProfileDropdownViewComponent(IUserService userService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = (await userService.GetByIdAsync(User.GetUserId())).Value;
        return View("AdminProfileDropdown", user);
    }
}