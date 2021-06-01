using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using mc.Configuration;
using mc.Web;

namespace mc.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class mcDbContextFactory : IDesignTimeDbContextFactory<mcDbContext>
    {
        public mcDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<mcDbContext>();
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder(),
                addUserSecrets: true
            );

            mcDbContextConfigurer.Configure(builder, configuration.GetConnectionString(mcConsts.ConnectionStringName));

            return new mcDbContext(builder.Options);
        }
    }
}