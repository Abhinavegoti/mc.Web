using System.Threading.Tasks;
using Abp.Application.Services;
using mc.Install.Dto;

namespace mc.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}