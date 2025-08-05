using Aref.Application.Services.Interfaces;
using Aref.Domain.ViewModels.SocialMedia.Client;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Components;

public class SocialMediaViewComponent(ISocialMediaService socialMediaService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(ClientFilterSocialMediaViewModel filter)
    {
        filter.TakeEntity = int.MaxValue;
        var result = await socialMediaService.FilterAsync(filter);
        
        return View("SocialMedia", result);
    }
}
