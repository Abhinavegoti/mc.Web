using Abp.AspNetCore.Mvc.ViewComponents;

namespace mc.Web.Public.Views
{
    public abstract class mcViewComponent : AbpViewComponent
    {
        protected mcViewComponent()
        {
            LocalizationSourceName = mcConsts.LocalizationSourceName;
        }
    }
}