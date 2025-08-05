using System.ComponentModel.DataAnnotations;
using Aref.Domain.Shared;

namespace Aref.Domain.ViewModels.ContactMe.Admin;

public class AdminContactMeViewModel
{
    public short Id { get; set; }
        
    
    [Display(Name = "Full Name")]
    public string FullName { get; set; }
        
    
    [Display(Name = "Mobile")]
    [RegularExpression(SiteRegex.MobileRegex, ErrorMessage = ErrorMessages.NotValid)]
    public string Mobile { get; set; }
        
    [Display(Name = "Created Date")]
    public DateTime CreatedDate { get; set; }
        

    public bool IsDeleted { get; set; }
}