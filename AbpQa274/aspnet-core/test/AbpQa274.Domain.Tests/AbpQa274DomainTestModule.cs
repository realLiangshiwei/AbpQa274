using AbpQa274.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpQa274
{
    [DependsOn(
        typeof(AbpQa274EntityFrameworkCoreTestModule)
        )]
    public class AbpQa274DomainTestModule : AbpModule
    {

    }
}