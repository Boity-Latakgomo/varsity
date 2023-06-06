using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace varsity.Authorization
{
    public class varsityAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Rolesd"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            //custom
            context.CreatePermission(PermissionNames.Service_Lecture, L("Lecture"));
            context.CreatePermission(PermissionNames.Service_Student, L("Student"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, varsityConsts.LocalizationSourceName);
        }
    }
}
