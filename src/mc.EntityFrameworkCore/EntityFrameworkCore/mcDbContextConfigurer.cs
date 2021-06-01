using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace mc.EntityFrameworkCore
{
    public static class mcDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<mcDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<mcDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}