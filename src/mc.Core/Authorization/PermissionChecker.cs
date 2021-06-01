using Abp.Authorization;
using mc.Authorization.Roles;
using mc.Authorization.Users;

namespace mc.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
