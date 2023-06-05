using System.Threading.Tasks;
using Abp.Application.Services;
using varsity.Authorization.Accounts.Dto;

namespace varsity.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
