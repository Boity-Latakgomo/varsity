using Abp.Application.Services.Dto;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.Dto_s;
using varsity.Service.LectureModule;
namespace varsity.Service.ModuleStudentService
{
    public class ModuleStudentAppService : ApplicationService, IModuleStudentAppService
    {

        private readonly IRepository<ModuleStudent, Guid> _repository;
        private readonly IRepository<Student, Guid> _student;
        private readonly IRepository<Student, Guid> student;
        private readonly IRepository<Module, Guid> _module;

        public ModuleStudentAppService(IRepository<ModuleStudent, Guid> repository, IRepository<Student, Guid> student, IRepository<Module, Guid> module)
        {
            _repository = repository;
            _student = student;
            _module = module;
        }

        public async Task<ModuleStudentDto> CreateAsync(ModuleStudentDto input)
        {
            var student = await _student.GetAsync((Guid)input.StudentId);
            if (student == null)
            {

            }

            var module = await _module.GetAsync((Guid)input.ModuleId);
            if (module == null)
            {

            }

            var ModuleStudent = new ModuleStudent
            {
                StudentId = (Guid)input.StudentId,
                ModuleId = (Guid)input.ModuleId,
            };

            await _repository.InsertAsync(ModuleStudent);

            var ModuleStudentDto = new ModuleStudentDto
            {
                StudentId = ModuleStudent.StudentId,
                ModuleId = ModuleStudent.ModuleId
            };

            return ModuleStudentDto;
        }



        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<ModuleStudentDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var query = _repository.GetAllIncluding(m => m.Student);
                var result = new PagedResultDto<ModuleStudentDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<ModuleStudentDto>>(query);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //public async Task<QuestionDto> GetAsync(Guid id)
        //{
        //    var question = await _repository.GetAllIncluding(c => c.Person).FirstOrDefaultAsync(c => c.Id == id);//we want a course associated with its department by course id
        //    if (question == null)
        //    {
        //        throw new Exception($"Course with ID '{id}' not found.");
        //    }

        //    return ObjectMapper.Map<QuestionDto>(question);
        //}

        public Task<ModuleStudentDto> UpdateAsync(ModuleStudentDto input)
        {
            throw new NotImplementedException();
        }
    }
}

