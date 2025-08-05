using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;

namespace Aref.Domain.ViewModels.ContactMe.Client;

public class ClientCreateContactMeViewModel
{
    [Display(Name = "Subject")] 
    [MaxLength(200, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? Subject { get; set; }
    
    [MaxLength(200, ErrorMessage = ErrorMessages.MaxLengthError)]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    [Display(Name = "Phone Number")]
    [MaxLength(11, ErrorMessage = ErrorMessages.MaxLengthError)]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [RegularExpression(SiteRegex.MobileRegex, ErrorMessage = ErrorMessages.NotValid)]
    public string Mobile { get; set; }

    [Display(Name = "Email")]
    [MaxLength(47, ErrorMessage = ErrorMessages.MaxLengthError)]
    [RegularExpression(SiteRegex.EmailRegex, ErrorMessage = ErrorMessages.NotValid)]
    public string? Email { get; set; }
    
    [Display(Name = "Message")]
    [MaxLength(1490, ErrorMessage = ErrorMessages.MaxLengthError)]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    public string Message { get; set; }
        
}