using Abp.Modules;
using Abp.Reflection.Extensions;

namespace mc
{
    [DependsOn(typeof(mcXamarinSharedModule))]
    public class mcXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(mcXamarinIosModule).GetAssembly());
        }
    }
}