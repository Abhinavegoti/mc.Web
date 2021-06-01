using Microsoft.Extensions.Configuration;

namespace mc.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
