using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.Dtos;

namespace varsity.Service.StudentPoolService
{
    public class StudentPoolAppService: ApplicationService, IStudentPoolAppService
    {
        private readonly IRepository<StudentPool, Guid> _studentPoolRepository;

        public StudentPoolAppService(IRepository<StudentPool, Guid> studentPoolRepository)
        {
            _studentPoolRepository = studentPoolRepository;
        }

        public async Task<StudentPoolDto> CreateAsync(StudentPoolDto input)
        {
            return ObjectMapper.Map<StudentPoolDto>(await _studentPoolRepository.InsertAsync(ObjectMapper.Map<StudentPool>(input)));
        }
    }
}
