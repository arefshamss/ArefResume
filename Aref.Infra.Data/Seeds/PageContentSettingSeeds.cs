using Aref.Domain.Models.PageContent;

namespace Aref.Infra.Data.Seeds;

public static class PageContentSettingSeeds
{
    public static List<PageContentSetting> PageContentSettings =
    [
        new()
        {
            Id = 1,
            AboutMeVisibility = true,
            MyResumeVisibility = false,
            MySkillVisibility = false,
            MyProjectVisibility = false,
            ContactMeVisibility = true,
            CreatedDate = SeedStaticDateTime.Date,
            IsDeleted = false
        }
    ];
}