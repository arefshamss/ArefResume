using Aref.Application.Services.Interfaces;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.CaptchaSetting;
using Aref.Infra.Data.Statics;
using Aref.Web.Areas.Admin.Controllers.Common;
using Aref.Web.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Controllers
{
    [InvokePermission(PermissionsName.UpdateCaptchaSetting)]
    public class CaptchaSettingController(ICaptchaSettingService captchaSettingService) : AdminBaseController
    {
        [InvokePermission(PermissionsName.UpdateCaptchaSetting)]
        public async Task<IActionResult> Update()
        {
            var result = await captchaSettingService.FillModelForEditAsync();
            return View(result);
        }

        [InvokePermission(PermissionsName.UpdateCaptchaSetting)]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AdminUpdateCaptchaSettingViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData[ToasterErrorMessage] = ErrorMessages.NullValue;
                return View(viewModel);
            }

            var result = await captchaSettingService.UpdateCaptchaSettingsAsync(viewModel);

            if (result.IsFailure)
            {
                TempData[ToasterErrorMessage] = result.Message;
                return View(viewModel);
            }

            TempData[ToasterSuccessMessage] = result.Message;
            return RedirectToAction(nameof(Update));
        }
    }
}
