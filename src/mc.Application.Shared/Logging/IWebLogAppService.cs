using Abp.Application.Services;
using mc.Dto;
using mc.Logging.Dto;

namespace mc.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
