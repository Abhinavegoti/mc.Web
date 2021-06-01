using Abp.Modules;
using mc.Test.Base;

namespace mc.Tests
{
    [DependsOn(typeof(mcTestBaseModule))]
    public class mcTestModule : AbpModule
    {
       
    }
}
