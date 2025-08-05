using Aref.Domain.Models.Permission;
using Aref.Infra.Data.Statics;

namespace Aref.Infra.Data.Seeds;

public static class PermissionSeeds
{
    public static List<Permission> ApplicationPermissions { get; } =
        new()
        {
            #region Admin Dashboard

            new()
            {
                Id = 1,
                ParentId = null,
                UniqueName = PermissionsName.AdminDashboard,
                DisplayName = "Permission.AdminDashboard"
            },

            #endregion

            #region User

            new()
            {
                Id = 2,
                ParentId = 1,
                UniqueName = PermissionsName.UserManagement,
                DisplayName = "Permission.UserManagement"
            },
            new()
            {
                Id = 3,
                ParentId = 2,
                UniqueName = PermissionsName.UserList,
                DisplayName = "Permission.UserList"
            },
            new()
            {
                Id = 4,
                ParentId = 2,
                UniqueName = PermissionsName.CreateUser,
                DisplayName = "Permission.CreateUser"
            },
            new()
            {
                Id = 5,
                ParentId = 2,
                UniqueName = PermissionsName.UpdateUser,
                DisplayName = "Permission.UpdateUser"
            },
            new()
            {
                Id = 6,
                ParentId = 2,
                UniqueName = PermissionsName.UserDetails,
                DisplayName = "Permission.UserDetail"
            },
            new()
            {
                Id = 7,
                ParentId = 2,
                UniqueName = PermissionsName.DeleteOrRecoverUser,
                DisplayName = "Permission.DeleteOrRecoverUser"
            },

            #endregion

            #region Role

            new()
            {
                Id = 8,
                ParentId = 1,
                UniqueName = PermissionsName.RoleManagement,
                DisplayName = "Permission.RoleManagement"
            },
            new()
            {
                Id = 9,
                ParentId = 8,
                UniqueName = PermissionsName.RoleList,
                DisplayName = "Permission.RoleList"
            },
            new()
            {
                Id = 10,
                ParentId = 8,
                UniqueName = PermissionsName.CreateRole,
                DisplayName = "Permission.CreateRole"
            },
            new()
            {
                Id = 11,
                ParentId = 8,
                UniqueName = PermissionsName.UpdateRole,
                DisplayName = "Permission.UpdateRole"
            },
            new()
            {
                Id = 12,
                ParentId = 8,
                UniqueName = PermissionsName.SetPermissionToRole,
                DisplayName = "Permission.SetPermissionToRole"
            },
            new()
            {
                Id = 13,
                ParentId = 8,
                UniqueName = PermissionsName.DeleteOrRecoverRole,
                DisplayName = "Permission.DeleteOrRecoverRole"
            },
            new()
            {
                Id = 14,
                ParentId = 8,
                UniqueName = PermissionsName.SetRoleToUser,
                DisplayName = "Permission.SetRoleToUser"
            },

            #endregion
            
            #region PageContent

            new()
            {
                Id = 15,
                ParentId = 1,
                UniqueName = PermissionsName.PageContentManagement,
                DisplayName = "Permission.PageContentManagement"
            },
            new()
            {
                Id = 16,
                ParentId = 15,
                UniqueName = PermissionsName.UpdatePageContent,
                DisplayName = "Permission.UpdatePageContent"
            },
            
            #endregion            
            
            #region MyService

            new()
            {
                Id = 17,
                ParentId = 1,
                UniqueName = PermissionsName.MyServiceManagement,
                DisplayName = "Permission.MyServiceManagement"
            },
            new()
            {
                Id = 18,
                ParentId = 17,
                UniqueName = PermissionsName.MyServiceList,
                DisplayName = "Permission.MyServiceList"
            },
            new()
            {
                Id = 19,
                ParentId = 17,
                UniqueName = PermissionsName.CreateMyService,
                DisplayName = "Permission.CreateMyService"
            },
            new()
            {
                Id = 20,
                ParentId = 17,
                UniqueName = PermissionsName.UpdateMyService,
                DisplayName = "Permission.UpdateMyService"
            },
            new()
            {
                Id = 21,
                ParentId = 17,
                UniqueName = PermissionsName.DeleteOrRecoverMyService,
                DisplayName = "Permission.DeleteOrRecoverMyService"
            },
            
            #endregion
            
            #region CounterBox

            new()
            {
                Id = 22,
                ParentId = 1,
                UniqueName = PermissionsName.CounterBoxManagement,
                DisplayName = "Permission.CounterBoxManagement"
            },
            new()
            {
                Id = 23,
                ParentId = 22,
                UniqueName = PermissionsName.CounterBoxList,
                DisplayName = "Permission.CounterBoxList"
            },
            new()
            {
                Id = 24,
                ParentId = 22,
                UniqueName = PermissionsName.CreateCounterBox,
                DisplayName = "Permission.CreateCounterBox"
            },
            new()
            {
                Id = 25,
                ParentId = 22,
                UniqueName = PermissionsName.UpdateCounterBox,
                DisplayName = "Permission.UpdateCounterBox"
            },
            new()
            {
                Id = 26,
                ParentId = 22,
                UniqueName = PermissionsName.DeleteOrRecoverCounterBox,
                DisplayName = "Permission.DeleteOrRecoverCounterBox"
            },
            
            #endregion
            
            #region MyResume

            new()
            {
                Id = 27,
                ParentId = 1,
                UniqueName = PermissionsName.MyResumeManagement,
                DisplayName = "Permission.MyResumeManagement"
            },
            new()
            {
                Id = 28,
                ParentId = 27,
                UniqueName = PermissionsName.MyResumeList,
                DisplayName = "Permission.MyResumeList"
            },
            new()
            {
                Id = 29,
                ParentId = 27,
                UniqueName = PermissionsName.CreateMyResume,
                DisplayName = "Permission.CreateMyResume"
            },
            new()
            {
                Id = 30,
                ParentId = 27,
                UniqueName = PermissionsName.UpdateMyResume,
                DisplayName = "Permission.UpdateMyResume"
            },
            new()
            {
                Id = 31,
                ParentId = 27,
                UniqueName = PermissionsName.DeleteOrRecoverMyResume,
                DisplayName = "Permission.DeleteOrRecoverMyResume"
            },
            
            #endregion
                                    
            #region MySkill

            new()
            {
                Id = 32,
                ParentId = 1,
                UniqueName = PermissionsName.MySkillManagement,
                DisplayName = "Permission.MySkillManagement"
            },
            new()
            {
                Id = 33,
                ParentId = 32,
                UniqueName = PermissionsName.MySkillList,
                DisplayName = "Permission.MySkillList"
            },
            new()
            {
                Id = 34,
                ParentId = 32,
                UniqueName = PermissionsName.CreateMySkill,
                DisplayName = "Permission.CreateMySkill"
            },
            new()
            {
                Id = 35,
                ParentId = 32,
                UniqueName = PermissionsName.UpdateMySkill,
                DisplayName = "Permission.UpdateMySkill"
            },
            new()
            {
                Id = 36,
                ParentId = 32,
                UniqueName = PermissionsName.DeleteOrRecoverMySkill,
                DisplayName = "Permission.DeleteOrRecoverMySkill"
            },
            
            #endregion  
            
            #region MyProject

            new()
            {
                Id = 37,
                ParentId = 1,
                UniqueName = PermissionsName.MyProjectManagement,
                DisplayName = "Permission.MyProjectManagement"
            },
            new()
            {
                Id = 38,
                ParentId = 37,
                UniqueName = PermissionsName.MyProjectList,
                DisplayName = "Permission.MyProjectList"
            },
            new()
            {
                Id = 39,
                ParentId = 37,
                UniqueName = PermissionsName.CreateMyProject,
                DisplayName = "Permission.CreateMyProject"
            },
            new()
            {
                Id = 40,
                ParentId = 37,
                UniqueName = PermissionsName.UpdateMyProject,
                DisplayName = "Permission.UpdateMyProject"
            },
            new()
            {
                Id = 41,
                ParentId = 37,
                UniqueName = PermissionsName.DeleteOrRecoverMyProject,
                DisplayName = "Permission.DeleteOrRecoverMyProject"
            },
            
            #endregion
                        
            #region PageContentSetting

            new()
            {
                Id = 42,
                ParentId = 1,
                UniqueName = PermissionsName.PageContentSettingManagement,
                DisplayName = "Permission.PageContentSettingManagement"
            },
            new()
            {
                Id = 43,
                ParentId = 42,
                UniqueName = PermissionsName.UpdatePageContentSetting,
                DisplayName = "Permission.UpdatePageContentSetting"
            },
            
            #endregion    
            
            #region ContactMe

            new()
            {
                Id = 44,
                ParentId = 1,
                UniqueName = PermissionsName.ContactMeManagement,
                DisplayName = "Permission.ContactMeManagement"
            },
            new()
            {
                Id = 45,
                ParentId = 44,
                UniqueName = PermissionsName.ContactMeList,
                DisplayName = "Permission.ContactMeList"
            },
            new()
            {
                Id = 46,
                ParentId = 44,
                UniqueName = PermissionsName.ContactMeDetails,
                DisplayName = "Permission.ContactMeDetails"
            },
            new()
            {
                Id = 47,
                ParentId = 44,
                UniqueName = PermissionsName.DeleteOrRecoverContactMe,
                DisplayName = "Permission.DeleteOrRecoverContactMe"
            },
            
            #endregion
            
            #region SocialMedia

            new()
            {
                Id = 48,
                ParentId = 1,
                UniqueName = PermissionsName.SocialMediaManagement,
                DisplayName = "Permission.SocialMediaManagement"
            },
            new()
            {
                Id = 49,
                ParentId = 48,
                UniqueName = PermissionsName.SocialMediaList,
                DisplayName = "Permission.SocialMediaList"
            },
            new()
            {
                Id = 50,
                ParentId = 48,
                UniqueName = PermissionsName.CreateSocialMedia,
                DisplayName = "Permission.CreateSocialMedia"
            },
            new()
            {
                Id = 51,
                ParentId = 48,
                UniqueName = PermissionsName.UpdateSocialMedia,
                DisplayName = "Permission.UpdateSocialMedia"
            },
            new()
            {
                Id = 52,
                ParentId = 48,
                UniqueName = PermissionsName.DeleteOrRecoverSocialMedia,
                DisplayName = "Permission.DeleteOrRecoverSocialMedia"
            },
            
            #endregion
            
            #region MyInfo

            new()
            {
                Id = 53,
                ParentId = 1,
                UniqueName = PermissionsName.MyInfoManagement,
                DisplayName = "Permission.MyInfoManagement"
            },
            new()
            {
                Id = 54,
                ParentId = 53,
                UniqueName = PermissionsName.UpdateMyInfo,
                DisplayName = "Permission.UpdateMyInfo"
            },
            
            #endregion  
            
            #region Captcha

            new()
            {
                Id = 55,
                ParentId = 1,
                UniqueName = PermissionsName.CaptchaManagement,
                DisplayName = "Permission.CaptchaManagement"
            },
            new()
            {
                Id = 56,
                ParentId = 55,
                UniqueName = PermissionsName.CaptchaList,
                DisplayName = "Permission.CaptchaList"
            },
            new()
            {
                Id = 57,
                ParentId = 55,
                UniqueName = PermissionsName.UpdateCaptcha,
                DisplayName = "Permission.UpdateCaptcha"
            },
            new()
            {
                Id = 58,
                ParentId = 55,
                UniqueName = PermissionsName.UpdateCaptchaSetting,
                DisplayName = "Permission.UpdateCaptchaSetting"
            },

            #endregion
            // available Id : 59
        };
}