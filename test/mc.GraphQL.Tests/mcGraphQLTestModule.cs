using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using mc.Configure;
using mc.Startup;
using mc.Test.Base;

namespace mc.GraphQL.Tests
{
    [DependsOn(
        typeof(mcGraphQLModule),
        typeof(mcTestBaseModule))]
    public class mcGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(mcGraphQLTestModule).GetAssembly());
        }
    }
}