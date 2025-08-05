using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;

namespace Aref.Domain.ViewModels.Role.Admin;

public class AdminCreateRoleViewModel
{
    [Display(Name = "Title")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    [MaxLength(100, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string Name { get; set; }
}