using Abp.Application.Services;
using Abp.Application.Services.Dto;
using mc.Authorization.Permissions.Dto;

namespace mc.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
