namespace Aref.Application.Cache;

public static class CacheKeys
{
    #region Permissions

    public static readonly CacheKey UserRoleMappings = new("UserRoleMappings-{0}");
    
    public static readonly CacheKey RolePermissionMappings = new("RolePermissionMappings");

    #endregion
    
    #region Captcha

    public static readonly CacheKey CaptchaPrefix = new("Captcha");

    public static readonly CacheKey Captcha = new("Captcha-{0}");

    public static readonly CacheKey ArCaptchaSiteKey = new("CaptchaArSiteKey");

    #endregion
}