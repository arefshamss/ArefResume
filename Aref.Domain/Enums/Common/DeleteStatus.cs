using System.ComponentModel.DataAnnotations;

namespace Aref.Domain.Enums.Common;

public enum DeleteStatus : byte
{
    [Display(Name = "All")]
    All = 1,
    
    [Display(Name = "Deleted")]
    Deleted = 2,
    
    [Display(Name = "Not Deleted")]
    NotDeleted = 0
}