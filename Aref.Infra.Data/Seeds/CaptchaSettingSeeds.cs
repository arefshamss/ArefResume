using Aref.Domain.Enums.Captcha;
using Aref.Domain.Models.Captcha;

namespace Aref.Infra.Data.Seeds;

public class CaptchaSettingSeeds
{
    public static List<CaptchaSetting> CaptchaSettingList { get; } =
    [
        new()
        {
            CaptchaSection = CaptchaSection.Account,
            CaptchaType = CaptchaType.GoogleRecaptchaV3,
            Id = 1,
            CreatedDate = SeedStaticDateTime.Date,
        }
    ];
}