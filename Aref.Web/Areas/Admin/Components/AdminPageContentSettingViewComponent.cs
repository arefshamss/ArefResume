using Aref.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Components;

public class AdminPageContentSettingViewComponent(IPageContentSettingService pageContentSettingService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = (await pageContentSettingService.FillModelForUpdateAsync(1)).Value;
        return View("AdminPageContentSetting", result);
    }
}