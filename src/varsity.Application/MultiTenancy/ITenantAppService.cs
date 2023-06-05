using Abp.Application.Services;
using varsity.MultiTenancy.Dto;

namespace varsity.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

