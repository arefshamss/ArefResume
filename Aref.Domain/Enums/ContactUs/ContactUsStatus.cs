using System.ComponentModel.DataAnnotations;

namespace Aref.Domain.Enums.ContactUs;

public enum ContactUsStatus : byte
{
    [Display(Name = "All")]
    All,
    [Display(Name = "In progress")]
    InProcess,
    [Display(Name = "Answered")]
    IsAnswered,
}