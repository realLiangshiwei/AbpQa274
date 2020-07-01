using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpQa274.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class AbpQa274MigrationsDbContextFactory : IDesignTimeDbContextFactory<AbpQa274MigrationsDbContext>
    {
        public AbpQa274MigrationsDbContext CreateDbContext(string[] args)
        {
            AbpQa274EfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AbpQa274MigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new AbpQa274MigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
