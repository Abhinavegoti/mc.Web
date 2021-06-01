using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using mc.Authorization.Users.Dto;

namespace mc.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<ListResultDto<UserLoginAttemptDto>> GetRecentUserLoginAttempts();
    }
}
