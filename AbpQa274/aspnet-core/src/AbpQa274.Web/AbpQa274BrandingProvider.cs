using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace AbpQa274.Web
{
    [Dependency(ReplaceServices = true)]
    public class AbpQa274BrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpQa274";
    }
}
