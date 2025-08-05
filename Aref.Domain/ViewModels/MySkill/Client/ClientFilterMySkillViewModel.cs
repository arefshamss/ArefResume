using System.ComponentModel.DataAnnotations;
using Aref.Domain.Attributes;
using Aref.Domain.Enums.Common;
using Aref.Domain.ViewModels.Common;

namespace Aref.Domain.ViewModels.MySkill.Client;

public class ClientFilterMySkillViewModel : BasePaging<ClientMySkillViewModel>
{
    [Display(Name = "DeleteStatus"), FilterInput]
    public DeleteStatus DeleteStatus { get; set; }
}