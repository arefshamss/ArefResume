using Aref.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Components;

public class NavbarViewComponent(IPageContentSettingService pageContentSettingService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = (await pageContentSettingService.FillModelForUpdateAsync(1)).Value;
        return View("Navbar", result);
    }
}