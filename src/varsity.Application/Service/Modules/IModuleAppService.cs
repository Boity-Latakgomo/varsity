using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;

namespace varsity.Service.Modules
{ 
 public interface IModuleAppService: IApplicationService
    {
        Task<ModuleDto> CreateAsync(ModuleDto input);
        Task<ModuleDto> UpdateAsync(ModuleDto input);
        Task<PagedResultDto<ModuleDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<ModuleDto> GetAsync( Guid id);
        Task DeleteAsync(Guid id);

    }
}
