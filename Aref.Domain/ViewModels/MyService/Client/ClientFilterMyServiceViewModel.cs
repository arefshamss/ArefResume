using System.ComponentModel.DataAnnotations;
using Aref.Domain.Attributes;
using Aref.Domain.Enums.Common;
using Aref.Domain.ViewModels.Common;

namespace Aref.Domain.ViewModels.MyService.Client;

public class ClientFilterMyServiceViewModel : BasePaging<ClientMyServiceViewModel>
{
    [Display(Name = "DeleteStatus"), FilterInput]
    public DeleteStatus DeleteStatus { get; set; }
}