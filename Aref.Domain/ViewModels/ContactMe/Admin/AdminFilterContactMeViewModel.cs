using System.ComponentModel.DataAnnotations;
using Aref.Domain.Attributes;
using Aref.Domain.Enums.Common;
using Aref.Domain.Shared;
using Aref.Domain.ViewModels.Common;

namespace Aref.Domain.ViewModels.ContactMe.Admin;

public class AdminFilterContactMeViewModel : BasePaging<AdminContactMeViewModel>
{
    [Display(Name = "Subject"),FilterInput]
    public string? Subject { get; set; }
    

    [Display(Name = "Delete Status"),FilterInput]
    public DeleteStatus DeleteStatus { get; set; }
    
    
    [Display(Name = "Filter Order by"),FilterInput]
    public FilterOrderBy FilterOrderBy { get; set; }
}