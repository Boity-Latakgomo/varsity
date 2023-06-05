using Abp.Authorization;
using varsity.Authorization.Roles;
using varsity.Authorization.Users;

namespace varsity.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
