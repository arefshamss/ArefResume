using Newtonsoft.Json;

namespace Aref.Domain.ViewModels.Captcha;

public class CaptchaVerificationResponseViewModel
{
    [JsonProperty("success")]
    public bool Success { get; set; }
}