using Aref.Domain.Models.Captcha;
using Aref.Domain.Models.CounterBox;
using Aref.Domain.Models.MyInfo;
using Aref.Domain.Models.MyProject;
using Aref.Domain.Models.MyResume;
using Aref.Domain.Models.MyService;
using Aref.Domain.Models.MySkill;
using Aref.Domain.Models.PageContent;
using Aref.Domain.Models.Permission;
using Aref.Domain.Models.Role;
using Aref.Domain.Models.SocialMedia;
using Aref.Domain.Models.User;
using Aref.Infra.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Aref.Infra.Data.Context;

public class ArefContext(DbContextOptions<ArefContext> options) : DbContext(options)
{
    #region Db Sets

    #region User

    public DbSet<User> Users { get; set; }

    #endregion

    #region Role

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRoleMapping> UserRoleMappings { get; set; }

    #endregion

    #region Permission

    public DbSet<Permission> Permissions { get; set; }

    public DbSet<RolePermissionMapping> RolePermissionMappings { get; set; }

    #endregion

    #region MyService

    public DbSet<MyService> MyServices { get; set; }

    #endregion
    
    #region CounterBox

    public DbSet<CounterBox> CounterBoxes { get; set; }

    #endregion

    #region MyResume
    
    public DbSet<MyResume> MyResume { get; set; }

    #endregion

    #region PageContent

    public DbSet<PageContent> PageContents { get; set; }

    #endregion
    
    #region MySkill

    public DbSet<MySkill> MySkills { get; set; }

    #endregion    
    
    #region MyProject

    public DbSet<MyProject> MyProjects { get; set; }

    #endregion    
    
    #region SocialMedia

    public DbSet<SocialMedia> SocialMedia { get; set; }

    #endregion  
    
    #region PageContentSetting

    public DbSet<PageContentSetting> PageContentSetting { get; set; }

    #endregion
    
    #region MySkill

    public DbSet<MyInfo> MyInfos { get; set; }

    #endregion  
    
    #region Captcha

    public DbSet<Captcha> Captchas { get; set; }
    public DbSet<CaptchaSetting> CaptchaSettings { get; set; }

    #endregion    
    
    #endregion

    #region OnModelCreating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .AddApplicationSeeds()
            .ApplyConfigurationsFromAssembly(GetType().Assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);
    }

    #endregion
}