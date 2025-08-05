using System.ComponentModel.DataAnnotations;
using Aref.Domain.Attributes;
using Aref.Domain.Enums.Common;
using Aref.Domain.ViewModels.Common;

namespace Aref.Domain.ViewModels.MyService.Admin;

public class AdminFilterMyServiceViewModel: BasePaging<AdminMyServiceViewModel>
{
    [Display(Name = "Title"), FilterInput]
    public string? Title { get; set; }

    
    [Display(Name = "Delete Status"), FilterInput]
    public DeleteStatus DeleteStatus { get; set; }
}