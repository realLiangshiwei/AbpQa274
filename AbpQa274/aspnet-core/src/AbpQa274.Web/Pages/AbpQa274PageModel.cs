using AbpQa274.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpQa274.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class AbpQa274PageModel : AbpPageModel
    {
        protected AbpQa274PageModel()
        {
            LocalizationResourceType = typeof(AbpQa274Resource);
        }
    }
}