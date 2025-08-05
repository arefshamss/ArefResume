using System.ComponentModel.DataAnnotations;

namespace Aref.Domain.ViewModels.ContactMe.Admin;

public class AdminContactMeDetailsViewModel
{
    public short Id { get; set; }

    [Display(Name = "Full Name")] public string FullName { get; set; }

    [Display(Name = "Subject")] public string? Subject { get; set; }

    [Display(Name = "Mobile")] public string Mobile { get; set; }

    [Display(Name = "Email")] public string? Email { get; set; }

    [Display(Name = "Message")] public string Message { get; set; }

    [Display(Name = "Created Date")] public DateTime CreatedDate { get; set; }
}