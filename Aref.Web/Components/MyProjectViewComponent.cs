using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.MyProject.Client;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Components;

public class MyProjectViewComponent(IMyProjectService myProjectService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(ClientFilterMyProjectViewModel filterMy)
    {
        filterMy.TakeEntity = int.MaxValue;
        var result = await myProjectService.FilterAsync(filterMy);
        
        return View("MyProject", result);
    }
}