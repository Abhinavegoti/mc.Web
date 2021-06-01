using Abp.Domain.Services;

namespace mc
{
    public abstract class mcDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected mcDomainServiceBase()
        {
            LocalizationSourceName = mcConsts.LocalizationSourceName;
        }
    }
}
