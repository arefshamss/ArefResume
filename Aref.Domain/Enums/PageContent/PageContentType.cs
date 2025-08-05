using System.ComponentModel.DataAnnotations;

namespace Aref.Domain.Enums.PageContent;

public enum PageContentType
{
    [Display(Name = "About Me")]
    AboutMe,
    [Display(Name = "My Resume")]
    MyResume,
    [Display(Name = "My Skills")]
    MySkill,
    [Display(Name = "My Projects")]
    MyProject,
    [Display(Name = "Contact Me")]
    ContactMe,
}