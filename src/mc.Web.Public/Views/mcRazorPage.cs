using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace mc.Web.Public.Views
{
    public abstract class mcRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected mcRazorPage()
        {
            LocalizationSourceName = mcConsts.LocalizationSourceName;
        }
    }
}
