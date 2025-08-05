using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.MyResume.Client;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Components;

public class MyResumeViewComponent(IMyResumeService myResumeService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(ClientFilterMyResumeViewModel filter)
    {
        filter.TakeEntity = int.MaxValue;
        var result = await myResumeService.FilterAsync(filter);
        
        return View("MyResume", result);
    }
}