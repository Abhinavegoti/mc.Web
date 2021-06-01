using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace mc.Startup
{
    [DependsOn(typeof(mcCoreModule))]
    public class mcGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(mcGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}