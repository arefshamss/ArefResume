using Aref.Domain.Enums.PageContent;
using Aref.Domain.Models.Common;

namespace Aref.Domain.Models.PageContent;

public class PageContent:BaseEntity<short>
{
    #region Properties

    public string? Title { get; set; }
    public string? Description { get; set; }
    public PageContentType PageContentType { get; set; }

    #endregion

}