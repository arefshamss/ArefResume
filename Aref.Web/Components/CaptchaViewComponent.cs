using Aref.Application.Services.Interfaces;
using Aref.Domain.Enums.Captcha;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Components
{
    public class CaptchaViewComponent(ICaptchaService captchaService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CaptchaSection section)
        {
            var result = await captchaService.GetCaptchaBySectionAsync(section);

            return View("Captcha", result?.Value ?? null);
        }
    }
}
