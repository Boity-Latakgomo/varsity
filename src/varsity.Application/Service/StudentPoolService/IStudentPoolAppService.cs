using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;
using varsity.Service.Dtos;

namespace varsity.Service.StudentPoolService
{
    public interface IStudentPoolAppService:IApplicationService
    {
        Task<StudentPoolDto> CreateAsync(StudentPoolDto input);        
    }
}
