using Abp.Modules;
using Abp.Reflection.Extensions;

namespace mc
{
    public class mcCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(mcCoreSharedModule).GetAssembly());
        }
    }
}