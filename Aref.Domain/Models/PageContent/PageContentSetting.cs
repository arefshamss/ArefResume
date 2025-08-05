using Aref.Domain.Enums.PageContent;
using Aref.Domain.Models.Common;

namespace Aref.Domain.Models.PageContent;

public class PageContentSetting : BaseEntity<short>
{
    public bool AboutMeVisibility { get; set; }
    public bool MyResumeVisibility { get; set; }
    public bool MySkillVisibility { get; set; }
    public bool MyProjectVisibility { get; set; }
    public bool ContactMeVisibility { get; set; }
}