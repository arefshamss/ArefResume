using System.ComponentModel.DataAnnotations;
using Aref.Domain.Attributes;
using Aref.Domain.Enums.Common;
using Aref.Domain.ViewModels.Common;

namespace Aref.Domain.ViewModels.CounterBox.Admin;

public class AdminFilterCounterBoxViewModel: BasePaging<AdminCounterBoxViewModel>
{
    [Display(Name = "Title"), FilterInput]
    public string? Title { get; set; }

    
    [Display(Name = "Delete Status"), FilterInput]
    public DeleteStatus DeleteStatus { get; set; }
}