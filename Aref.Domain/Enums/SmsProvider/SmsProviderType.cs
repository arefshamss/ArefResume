using System.ComponentModel.DataAnnotations;

namespace Aref.Domain.Enums.SmsProvider;

public enum SmsProviderType : byte
{
    [Display(Name = "ParsGreen")]
    ParsGreen,
}