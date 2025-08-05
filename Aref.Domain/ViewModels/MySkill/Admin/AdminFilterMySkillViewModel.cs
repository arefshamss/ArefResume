using System.ComponentModel.DataAnnotations;
using Aref.Domain.Attributes;
using Aref.Domain.Enums.Common;
using Aref.Domain.ViewModels.Common;

namespace Aref.Domain.ViewModels.MySkill.Admin;

public class AdminFilterMySkillViewModel: BasePaging<AdminMySkillViewModel>
{
    [Display(Name = "Title"), FilterInput]
    public string? Title { get; set; }

    
    [Display(Name = "Delete Status"), FilterInput]
    public DeleteStatus DeleteStatus { get; set; }
}