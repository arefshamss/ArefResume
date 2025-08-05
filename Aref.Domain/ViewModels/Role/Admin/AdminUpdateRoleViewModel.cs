using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;

namespace Aref.Domain.ViewModels.Role.Admin;

public class AdminUpdateRoleViewModel
{
    public short Id { get; set; }

    [Display(Name = "Title")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(250, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Name { get; set; }
}