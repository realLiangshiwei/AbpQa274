using System;
using System.Collections.Generic;
using System.Text;
using AbpQa274.Localization;
using Volo.Abp.Application.Services;

namespace AbpQa274
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpQa274AppService : ApplicationService
    {
        protected AbpQa274AppService()
        {
            LocalizationResource = typeof(AbpQa274Resource);
        }
    }
}
