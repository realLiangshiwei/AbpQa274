using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace AbpQa274.EntityFrameworkCore
{
    public static class AbpQa274DbContextModelCreatingExtensions
    {
        public static void ConfigureAbpQa274(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(AbpQa274Consts.DbTablePrefix + "YourEntities", AbpQa274Consts.DbSchema);

            //    //...
            //});
        }
    }
}