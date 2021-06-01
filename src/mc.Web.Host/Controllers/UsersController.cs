using Abp.AspNetCore.Mvc.Authorization;
using mc.Authorization;
using mc.Storage;
using Abp.BackgroundJobs;

namespace mc.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}