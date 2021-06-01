using Abp.Modules;
using Abp.Reflection.Extensions;

namespace mc
{
    [DependsOn(typeof(mcXamarinSharedModule))]
    public class mcXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(mcXamarinAndroidModule).GetAssembly());
        }
    }
}