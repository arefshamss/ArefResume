using Aref.Application.Services.Interfaces;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.Captcha;
using Aref.Infra.Data.Statics;
using Aref.Web.Areas.Admin.Controllers.Common;
using Aref.Web.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Areas.Admin.Controllers
{
    [InvokePermission(PermissionsName.CaptchaManagement)]
    public class CaptchaController(ICaptchaService captchaService) : AdminBaseController
    {
        #region List

        [InvokePermission(PermissionsName.CaptchaList)]
        public async Task<IActionResult> List()
        {
            var result = await captchaService.GetAllCaptchaAsync();
            return View(result);
        }

        #endregion

        #region Create

        [InvokePermission(PermissionsName.UpdateCaptcha)]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [InvokePermission(PermissionsName.UpdateCaptcha)]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCreateCaptchaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData[ToasterErrorMessage] = ErrorMessages.NullValue;
                return View(viewModel);
            }

            var result = await captchaService.CreateCaptchaAsync(viewModel);

            if (result.IsFailure)
            {
                TempData[ToasterErrorMessage] = result.Message;
                return View(viewModel);
            }

            TempData[ToasterSuccessMessage] = result.Message;
            return RedirectToAction(nameof(List));
        }

        #endregion

        #region Update

        [InvokePermission(PermissionsName.UpdateCaptcha)]
        public async Task<IActionResult> Update(short id)
        {
            var result = await captchaService.FillModelForEditAsync(id);
            if (result.IsFailure)
            {
                TempData[ToasterErrorMessage] = result.Message;
                return RedirectToRefererUrl();
            }

            return View(result.Value);
        }

        [InvokePermission(PermissionsName.UpdateCaptcha)]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AdminUpdateCaptchaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData[ToasterErrorMessage] = ErrorMessages.NullValue;
                return View(viewModel);
            }

            var result = await captchaService.UpdateCaptchaAsync(viewModel);

            if (result.IsFailure)
            {
                TempData[ToasterErrorMessage] = result.Message;
                return View(viewModel);
            }

            TempData[ToasterSuccessMessage] = result.Message;
            return RedirectToAction(nameof(List));
        }

        #endregion
    }
}
