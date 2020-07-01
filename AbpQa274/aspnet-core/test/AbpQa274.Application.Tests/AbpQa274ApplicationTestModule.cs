using Volo.Abp.Modularity;

namespace AbpQa274
{
    [DependsOn(
        typeof(AbpQa274ApplicationModule),
        typeof(AbpQa274DomainTestModule)
        )]
    public class AbpQa274ApplicationTestModule : AbpModule
    {

    }
}