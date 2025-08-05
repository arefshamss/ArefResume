using Aref.Domain.Models.Captcha;
using Aref.Domain.Models.MyInfo;
using Aref.Domain.Models.PageContent;
using Aref.Domain.Models.Permission;
using Aref.Domain.Models.Role;
using Aref.Domain.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Aref.Infra.Data.Seeds;

public static class ApplicationSeeds
{
    public static ModelBuilder AddApplicationSeeds(this ModelBuilder modelBuilder)
    {
        #region Users

        modelBuilder.Entity<User>().HasData(UserSeeds.Users);

        #endregion
        
        #region Permissions

        modelBuilder.Entity<Permission>().HasData(PermissionSeeds.ApplicationPermissions);

        #endregion

        #region Role

        modelBuilder.Entity<Role>().HasData(RoleSeeds.Roles);

        #endregion

        #region RolePermission
        
        foreach (var permission in PermissionSeeds.ApplicationPermissions)
        {
            modelBuilder.Entity<RolePermissionMapping>().HasData([
                new(1, permission.Id) 
            ]);
        }

        #endregion
        
        #region UserRoleMappingSeeds
        
        modelBuilder.Entity<UserRoleMapping>().HasData(UserRoleMappingSeeds.UserRoleMappings);

        #endregion   
        
        #region PageContentSeeds
        
        modelBuilder.Entity<PageContent>().HasData(PageContentSeeds.PageContents);

        #endregion
        
        #region PageContentSettingSeeds
        
        modelBuilder.Entity<PageContentSetting>().HasData(PageContentSettingSeeds.PageContentSettings);

        #endregion     
        
        #region MyInfoSeeds
        
        modelBuilder.Entity<MyInfo>().HasData(MyInfoSeeds.MyInfos);

        #endregion
        
        #region Captcha

        modelBuilder.Entity<Captcha>().HasData(CaptchaSeeds.CaptchaList);

        modelBuilder.Entity<CaptchaSetting>().HasData(CaptchaSettingSeeds.CaptchaSettingList);

        #endregion

        return modelBuilder;
    }
}