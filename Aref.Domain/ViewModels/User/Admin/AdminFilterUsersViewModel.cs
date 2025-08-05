using System.ComponentModel.DataAnnotations;
using Aref.Domain.Attributes;
using Aref.Domain.Enums.Common;
using Aref.Domain.ViewModels.Common;

namespace Aref.Domain.ViewModels.User.Admin;

public class AdminFilterUsersViewModel : BasePaging<AdminUserViewModel>
{
    [Display(Name = "Delete Status")]
    [FilterInput]
    public DeleteStatus DeleteStatus { get; set; }  
}