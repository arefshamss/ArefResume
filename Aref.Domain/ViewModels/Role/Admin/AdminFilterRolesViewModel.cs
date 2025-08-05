using System.ComponentModel.DataAnnotations;
using Aref.Domain.Attributes;
using Aref.Domain.Enums.Common;
using Aref.Domain.ViewModels.Common;

namespace Aref.Domain.ViewModels.Role.Admin;

public class AdminFilterRolesViewModel : BasePaging<AdminRoleViewModel>
{
    [Display(Name = "Title")]
    [FilterInput]
    public string? Name { get; set; }

    [Display(Name = "Delete Status")]
    [FilterInput]
    public DeleteStatus DeleteStatus { get; set; }
}