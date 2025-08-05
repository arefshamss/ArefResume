using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.MyService.Client;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Components;

public class MyServiceViewComponent(IMyServiceService myServiceService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(ClientFilterMyServiceViewModel filterMy)
    {
        filterMy.TakeEntity = int.MaxValue;
        var result = await myServiceService.FilterAsync(filterMy);
        
        return View("MyService", result);
    }
}



