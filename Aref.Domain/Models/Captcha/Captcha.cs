using Aref.Domain.Enums.Captcha;
using Aref.Domain.Models.Common;

namespace Aref.Domain.Models.Captcha
{
    public class Captcha : BaseEntity<short>
    {
        #region Properties

        public string SiteKey { get; set; }

        public string SecretKey { get; set; }

        public CaptchaType CaptchaType { get; set; }

        public bool IsActive { get; set; }

        #endregion
    }
}
