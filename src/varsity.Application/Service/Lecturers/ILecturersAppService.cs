using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;

namespace varsity.Service.Lecturers
{
    public interface ILecturersAppService : IApplicationService
    {
        Task<LecturerDto> CreateAsync(LecturerDto input);
        //Task<LecturerDto> GetAsync(Guid id);
        //Task<List<LecturerDto>> GetAllAsync();
        //Task<LecturerDto> UpdateAsync(LecturerDto input);
        //Task Delete(Guid id);
    }
}
