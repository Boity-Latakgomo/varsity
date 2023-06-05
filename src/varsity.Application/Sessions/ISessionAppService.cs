using System.Threading.Tasks;
using Abp.Application.Services;
using varsity.Sessions.Dto;

namespace varsity.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
