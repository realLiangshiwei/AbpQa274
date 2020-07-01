using System.Threading.Tasks;

namespace AbpQa274.Data
{
    public interface IAbpQa274DbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
