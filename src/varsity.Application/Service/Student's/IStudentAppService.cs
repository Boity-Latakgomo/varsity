using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;

namespace varsity.Service.Student_s
{
    public interface IStudentAppService: IApplicationService
    {
        Task<StudentDto> CreateAsync(StudentDto input);
        Task<StudentDto> GetAsync(Guid id);
        Task<List<StudentDto>> GetAllAsync();
        Task<StudentDto> UpdateAsync(StudentDto input);
        Task Delete(Guid id);
    }
}
