using Aref.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Components;

public class PageContentViewComponent(IPageContentService pageContentService) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(short id)
    {
        var result = (await pageContentService.FillModelForUpdateAsync(id)).Value;
        return View("PageContent", result);
    }
}
