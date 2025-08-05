using Aref.Domain.Models.MyInfo;

namespace Aref.Infra.Data.Seeds;

public static class MyInfoSeeds
{
    public static List<MyInfo> MyInfos =
    [
        new()
        {
            Id = 1,
            FullName = "User Full Name",
            Mobile = "+989001112233",
            Email = "resume@sample.com",
            Title = "Sample Title",
            MobileVisibility = false,
            EmailVisibility = true,
            CvVisibility = false,
            TitleVisibility = true,
            CreatedDate = SeedStaticDateTime.Date,
            IsDeleted = false
        }
    ];
}