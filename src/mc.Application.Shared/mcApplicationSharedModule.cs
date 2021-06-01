using Abp.Modules;
using Abp.Reflection.Extensions;

namespace mc
{
    [DependsOn(typeof(mcCoreSharedModule))]
    public class mcApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(mcApplicationSharedModule).GetAssembly());
        }
    }
}