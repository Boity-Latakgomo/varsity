using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;

namespace varsity.Service.LectureModule
{
    
    public interface ILectureModuleAppService : IApplicationService
    {
        Task<LecturerModuleDto> CreateAsync(LecturerModuleDto input);
        Task<LecturerModuleDto> UpdateAsync(LecturerModuleDto input);
        Task<PagedResultDto<LecturerModuleDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
       // Task<LectureModuleDto> GetAsync(Guid id);
        Task DeleteAsync(Guid id);

    }
}
