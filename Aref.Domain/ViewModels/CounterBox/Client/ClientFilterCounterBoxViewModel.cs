using System.ComponentModel.DataAnnotations;
using Aref.Domain.Attributes;
using Aref.Domain.Enums.Common;
using Aref.Domain.ViewModels.Common;

namespace Aref.Domain.ViewModels.CounterBox.Client;

public class ClientFilterCounterBoxViewModel: BasePaging<ClientCounterBoxViewModel>
{
    [Display(Name = "Delete Status"), FilterInput]
    public DeleteStatus DeleteStatus { get; set; }
}