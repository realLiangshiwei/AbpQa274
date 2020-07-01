using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpQa274.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpQa274EntityFrameworkCoreModule)
        )]
    public class AbpQa274EntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpQa274MigrationsDbContext>();
        }
    }
}
