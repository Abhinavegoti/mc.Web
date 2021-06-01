using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace mc
{
    [DependsOn(typeof(mcClientModule), typeof(AbpAutoMapperModule))]
    public class mcXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(mcXamarinSharedModule).GetAssembly());
        }
    }
}