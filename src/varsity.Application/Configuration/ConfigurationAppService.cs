using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using varsity.Configuration.Dto;

namespace varsity.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : varsityAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
