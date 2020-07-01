using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpQa274.Data
{
    /* This is used if database provider does't define
     * IAbpQa274DbSchemaMigrator implementation.
     */
    public class NullAbpQa274DbSchemaMigrator : IAbpQa274DbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}