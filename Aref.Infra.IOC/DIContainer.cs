using Aref.Application.Services.Implementations;
using Aref.Application.Services.Interfaces;
using Aref.Domain.Contracts;
using Aref.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Aref.Infra.IOC
{
    public static class DIContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRoleMappingRepository, UserRoleMappingRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPageContentRepository, PageContentRepository>();
            services.AddScoped<IPageContentSettingRepository, PageContentSettingRepository>();
            services.AddScoped<ICounterBoxRepository, CounterBoxRepository>();
            services.AddScoped<IMyServiceRepository, MyServiceRepository>();
            services.AddScoped<IMyResumeRepository, MyResumeRepository>();
            services.AddScoped<IMySkillRepository, MySkillRepository>();
            services.AddScoped<IMyProjectRepository, MyProjectRepository>();
            services.AddScoped<IContactMeRepository, ContactMeRepository>();
            services.AddScoped<IMyInfoRepository, MyInfoRepository>();
            services.AddScoped<ISocialMediaRepository,SocialMediaRepository>();
            services.AddScoped<ICaptchaRepository,CaptchaRepository>();
            services.AddScoped<ICaptchaSettingRepository,CaptchaSettingRepository>();
            
            #endregion
            
            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<IMemoryCacheService, MemoryCacheService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPageContentService, PageContentService>();
            services.AddScoped<IPageContentSettingService, PageContentSettingService>();
            services.AddScoped<ICounterBoxService, CounterBoxService>();
            services.AddScoped<IMyServiceService, MyServiceService>();
            services.AddScoped<IMyResumeService, MyResumeService>();
            services.AddScoped<IMySkillService, MySkillService>();
            services.AddScoped<IMyProjectService, MyProjectService>();
            services.AddScoped<IContactMeService, ContactMeService>();
            services.AddScoped<IMyInfoService, MyInfoService>();
            services.AddScoped<ISocialMediaService,SocialMediaService>();
            services.AddScoped<ICaptchaService,CaptchaService>();
            services.AddScoped<ICaptchaSettingService,CaptchaSettingService>();
            
            #endregion
            
            return services;
        }
    }
}