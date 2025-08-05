using Aref.Domain.Enums.Captcha;
using Aref.Domain.Models.Common;

namespace Aref.Domain.Models.Captcha
{
    public class CaptchaSetting : BaseEntity<short>
    {
        #region Properties

        public CaptchaType CaptchaType { get; set; }

        public CaptchaSection CaptchaSection { get; set; }

        #endregion
    }
}
