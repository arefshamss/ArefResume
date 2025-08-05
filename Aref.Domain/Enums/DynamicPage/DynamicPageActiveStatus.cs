using System.ComponentModel.DataAnnotations;

namespace Aref.Domain.Enums.DynamicPage;

public enum DynamicPageActiveStatus : byte
{
    [Display(Name="All")]
    All,
    [Display(Name="Active")]
    Active,
    [Display(Name="Not Active")]
    NotActive
}

