using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpQa274.Data;
using Volo.Abp.DependencyInjection;

namespace AbpQa274.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpQa274DbSchemaMigrator
        : IAbpQa274DbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpQa274DbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpQa274MigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpQa274MigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}