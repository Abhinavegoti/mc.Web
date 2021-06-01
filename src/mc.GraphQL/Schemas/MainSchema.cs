using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using mc.Queries.Container;
using System;

namespace mc.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}