using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using mc.Authorization;

namespace mc
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(mcApplicationSharedModule),
        typeof(mcCoreModule)
        )]
    public class mcApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(mcApplicationModule).GetAssembly());
        }
    }
}