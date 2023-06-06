using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;

namespace varsity.Service.Course_s
{
    public interface ICourseAppService: IApplicationService
    {
        Task<CourseDto> CreateAsync(CourseDto input);
        Task<CourseDto> UpdateAsync(CourseDto input);
        Task<PagedResultDto<CourseDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        Task<CourseDto> GetAsync( Guid id);
        Task DeleteAsync(Guid id);

    }
}
