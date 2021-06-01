using Abp.AspNetCore.Mvc.Views;

namespace mc.Web.Views
{
    public abstract class mcRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected mcRazorPage()
        {
            LocalizationSourceName = mcConsts.LocalizationSourceName;
        }
    }
}
