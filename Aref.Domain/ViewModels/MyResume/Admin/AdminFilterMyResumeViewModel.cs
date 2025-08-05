using System.ComponentModel.DataAnnotations;
using Aref.Domain.Attributes;
using Aref.Domain.Enums.Common;
using Aref.Domain.Enums.MyResume;
using Aref.Domain.ViewModels.Common;

namespace Aref.Domain.ViewModels.MyResume.Admin;


public class AdminFilterMyResumeViewModel: BasePaging<AdminMyResumeViewModel>
{
    [Display(Name = "Title"), FilterInput]
    public string? Title { get; set; }
    
    [Display(Name = "MyResume Item Type"), FilterInput]
    public FilterMyResumeType ResumeType { get; set; }    
    
    [Display(Name = "Delete Status"), FilterInput]
    public DeleteStatus DeleteStatus { get; set; }
}