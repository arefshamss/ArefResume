using System.ComponentModel.DataAnnotations;
using Aref.Domain.Enums.PageContent;
using Aref.Domain.Shared;

namespace Aref.Domain.ViewModels.PageContentSetting.Admin;

public class AdminUpdatePageContentSettingViewModel
{
    public short Id { get; set; }

    [Display(Name = "About Me Visibility")]
    public bool AboutMeVisibility { get; set; }
    
    [Display(Name = "My Resume Visibility")]
    public bool MyResumeVisibility { get; set; }
    
    [Display(Name = "My Skill Visibility")]
    public bool MySkillVisibility { get; set; }
    
    [Display(Name = "My Project Visibility")]
    public bool MyProjectVisibility { get; set; }
    
    [Display(Name = "Contact Me Visibility")]
    public bool ContactMeVisibility { get; set; }
}