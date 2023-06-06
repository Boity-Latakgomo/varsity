using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;

namespace varsity.Service.ModuleStudentService
{
    public interface IModuleStudentAppService : IApplicationService
    {
        Task<ModuleStudentDto> CreateAsync(ModuleStudentDto input);
        Task<ModuleStudentDto> UpdateAsync(ModuleStudentDto input);
        Task<PagedResultDto<ModuleStudentDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        // Task<ModuleStudentDto> GetAsync(Guid id);
        Task DeleteAsync(Guid id);

    }
}
