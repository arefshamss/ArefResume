using Aref.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Components;

public class MyInfoViewComponent(IMyInfoService myInfoService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = (await myInfoService.FillModelForUpdateAsync(1)).Value;
        return View("MyInfo", result);
    }
}