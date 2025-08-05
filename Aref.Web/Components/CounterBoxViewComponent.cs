using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.CounterBox.Client;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Components;

public class CounterBoxViewComponent(ICounterBoxService counterBoxService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(ClientFilterCounterBoxViewModel filter)
    {
        filter.TakeEntity = int.MaxValue;
        var result = await counterBoxService.FilterAsync(filter);
        
        return View("CounterBox", result);
    }
}