using AbpQa274.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpQa274.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpQa274Controller : AbpController
    {
        protected AbpQa274Controller()
        {
            LocalizationResource = typeof(AbpQa274Resource);
        }
    }
}