using Aref.Domain.Enums.PageContent;
using Aref.Domain.Models.PageContent;

namespace Aref.Infra.Data.Seeds;

public static class PageContentSeeds
{
    public static List<PageContent> PageContents =
    [
        new()
        {
            Id = 1,
            Title = "",
            Description = "",
            PageContentType = PageContentType.AboutMe,
            CreatedDate = SeedStaticDateTime.Date,
            IsDeleted = false
        },
        new()
        {
            Id = 2,
            Title = "",
            Description = "",
            PageContentType = PageContentType.MyResume,
            CreatedDate = SeedStaticDateTime.Date,
            IsDeleted = false
        },
        new()
        {
            Id = 3,
            Title = "",
            Description = "",
            PageContentType = PageContentType.MySkill,
            CreatedDate = SeedStaticDateTime.Date,
            IsDeleted = false
        },
        new()
        {
            Id = 4,
            Title = "",
            Description = "",
            PageContentType = PageContentType.MyProject,
            CreatedDate = SeedStaticDateTime.Date,
            IsDeleted = false
        },
        new()
        {
            Id = 5,
            Title = "",
            Description = "",
            PageContentType = PageContentType.ContactMe,
            CreatedDate = SeedStaticDateTime.Date,
            IsDeleted = false
        }
    ];
}