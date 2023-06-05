using System.Threading.Tasks;
using varsity.Configuration.Dto;

namespace varsity.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
