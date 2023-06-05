using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace varsity.Controllers
{
    public abstract class varsityControllerBase: AbpController
    {
        protected varsityControllerBase()
        {
            LocalizationSourceName = varsityConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
