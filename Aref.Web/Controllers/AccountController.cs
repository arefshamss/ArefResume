using System.Security.Claims;
using Aref.Application.Services.Interfaces;
using Aref.Domain.Enums.Captcha;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.User.Admin;
using Aref.Web.Common;
using Aref.Web.Controllers.Common;
using Aref.Web.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Aref.Web.Controllers;

public class AccountController(
    IUserService userService,
    ICaptchaService captchaService) : SiteBaseController
{
    #region Login

    [HttpGet(RoutingExtension.Admin.Account.Login)]
    public IActionResult Login()
    {
        if (UserIsAuthenticated())
            return RedirectToAction("Index", "Home", new { area = "Admin" });

        return View();
    }

    [HttpPost(RoutingExtension.Admin.Account.Login)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ShowToasterErrorMessage(ErrorMessages.ModelStateNotValid);
            return View(viewModel);
        }

        #region Captcha

        if (viewModel.CaptchaType == CaptchaType.GoogleRecaptchaV2)
            viewModel.CaptchaToken = Request.Form["g-recaptcha-response"];

        if (!await captchaService.VerifyCaptchaAsync(viewModel.CaptchaType, viewModel.CaptchaToken, viewModel.SecretKey!))
        {
            ShowToasterErrorMessage(ErrorMessages.CaptchaError);
            return View(viewModel);
        }

        #endregion

        var result = await userService.ConfirmLoginAsync(viewModel);

        if (result.IsFailure)
        {
            ShowToasterErrorMessage(result.Message);
            return View(viewModel);
        }

        await LoginUserAsync(new()
        {
            FullName = result.Value.FullName,
            Mobile = result.Value.Mobile,
            UserId = result.Value.UserId
        },viewModel.RememberMe);

        ShowToasterSuccessMessage(result.Message);
        
        return RedirectToAction("Index", "Home", new { area = "Admin"});
    }

    #endregion

    #region Logout

    [HttpGet(RoutingExtension.Site.Account.Logout)]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home", new { area = "" });
    }

    #endregion

    #region Helpers

    private bool UserIsAuthenticated()
        => User.Identity?.IsAuthenticated ?? false;

    private async Task LoginUserAsync(AuthenticateUserViewModel viewModel, bool rememberMe)
    {
        List<Claim> claims =
        [
            new(ClaimTypes.NameIdentifier, viewModel.UserId.ToString()),
            new(ClaimTypes.Name, viewModel.FullName ?? ""),
            new(ClaimTypes.MobilePhone, viewModel.Mobile ?? ""),
        ];

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var principal = new ClaimsPrincipal(identity);
        var properties = new AuthenticationProperties
        {
            IsPersistent = rememberMe,
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
        };
        await HttpContext.SignInAsync(principal, properties);
    }

    #endregion
}