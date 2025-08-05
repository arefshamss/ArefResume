using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.MySkill.Client;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Components;

public class MySkillViewComponent(IMySkillService mySkillService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(ClientFilterMySkillViewModel filter)
    {
        filter.TakeEntity = int.MaxValue;
        var result = await mySkillService.FilterAsync(filter);
        
        return View("MySkill", result);
    }
}
