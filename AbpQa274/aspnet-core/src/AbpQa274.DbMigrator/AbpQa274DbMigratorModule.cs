using AbpQa274.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpQa274.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpQa274EntityFrameworkCoreDbMigrationsModule),
        typeof(AbpQa274ApplicationContractsModule)
        )]
    public class AbpQa274DbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
