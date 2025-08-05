using Aref.Domain.Enums.Captcha;
using Aref.Domain.Models.Captcha;

namespace Aref.Infra.Data.Seeds;

public class CaptchaSeeds
{
    public static List<Captcha> CaptchaList { get; } =
    [
        new()
        {
            Id = 2,
            CaptchaType = CaptchaType.GoogleRecaptchaV2,
            CreatedDate = SeedStaticDateTime.Date,
            IsActive = true,
            SiteKey = "6LfhYIMqAAAAANG-u6hSXn78NNaHkh9YC0Dl8A9k",
            SecretKey = "6LfhYIMqAAAAAMnSYhdAQQIQ0xfoT4jB0M3n4hjt"
        },
        new()
        {
            Id = 3,
            CaptchaType = CaptchaType.GoogleRecaptchaV3,
            CreatedDate = SeedStaticDateTime.Date,
            IsActive = true,
            SiteKey = "6LdlYYMqAAAAAMZPw2mzADp3pSNynHA2UQ5svTWA",
            SecretKey = "6LdlYYMqAAAAAOBvpRDN6dYVJyF91VT91LZNi0Rk"
        },
    ];
}