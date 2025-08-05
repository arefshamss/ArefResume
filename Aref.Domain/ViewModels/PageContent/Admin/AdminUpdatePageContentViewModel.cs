using System.ComponentModel.DataAnnotations;
using Aref.Domain.Enums.PageContent;
using Aref.Domain.Shared;

namespace Aref.Domain.ViewModels.PageContent.Admin;

public class AdminUpdatePageContentViewModel
{
    public short Id { get; set; }

    [Display(Name = "Title")]
    [MaxLength(500, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? Title { get; set; }


    [Display(Name = "Description")]
    [MaxLength(10000, ErrorMessage = ErrorMessages.MaxLengthError)]
    public string? Description { get; set; }
    
        
    [Display(Name = "Page Type")]
    [Required(ErrorMessage = ErrorMessages.RequiredError)]
    public PageContentType PageContentType { get; set; }
}