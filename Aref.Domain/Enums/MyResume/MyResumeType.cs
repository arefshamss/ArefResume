using System.ComponentModel.DataAnnotations;

namespace Aref.Domain.Enums.MyResume;

public enum MyResumeType : byte
{
    [Display(Name = "None")]
    None,
    [Display(Name = "Education")]
    Education,
    [Display(Name = "Experience")]
    Experience,
    [Display(Name = "Certification & Courses")]
    Courses
}

public enum FilterMyResumeType : byte
{
    [Display(Name = "All")]
    All,
    [Display(Name = "None")]
    None,
    [Display(Name = "Education")]
    Education,
    [Display(Name = "Experience")]
    Experience,
    [Display(Name = "Certification & Courses")]
    Courses
}