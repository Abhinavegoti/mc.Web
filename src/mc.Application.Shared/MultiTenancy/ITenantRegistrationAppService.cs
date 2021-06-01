using System.Threading.Tasks;
using Abp.Application.Services;
using mc.Editions.Dto;
using mc.MultiTenancy.Dto;

namespace mc.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}