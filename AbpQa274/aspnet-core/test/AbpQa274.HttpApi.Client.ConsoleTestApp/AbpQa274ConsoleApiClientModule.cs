using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace AbpQa274.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(AbpQa274HttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AbpQa274ConsoleApiClientModule : AbpModule
    {
        
    }
}
