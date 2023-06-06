using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;
using Abp.Domain.Repositories;
using varsity.Domain;
using varsity.Service.Answers;

namespace varsity.Service.LectureModule
{
    public class LecturerModuleAppService : ApplicationService, ILectureModuleAppService
    {

        private readonly IRepository<LecturerModule, Guid> _repository;
        private readonly IRepository<Lecturer, Guid> _lecturer;
        private readonly IRepository<Lecturer, Guid> lecturer;
        private readonly IRepository<Module, Guid> _module;

        public LecturerModuleAppService(IRepository<LecturerModule, Guid> repository, IRepository<Lecturer, Guid> lecturer, IRepository<Module, Guid> module)
        {
            _repository = repository;
            _lecturer = lecturer;
            _module = module;
        }

        public async Task<LecturerModuleDto> CreateAsync(LecturerModuleDto input)
        {
            var lecturer = await _lecturer.GetAsync((Guid)input.LecturerId);
            if (lecturer == null)
            {

            }

            var module = await _module.GetAsync((Guid)input.ModuleId);
            if (module == null)
            {

            }

            var lecturerModule = new LecturerModule
            {
                LecturerId = (Guid)input.LecturerId,
                ModuleId = (Guid)input.ModuleId,                
            };

            await _repository.InsertAsync(lecturerModule);

            var lecturerModuleDto = new LecturerModuleDto
            {
                LecturerId = lecturerModule.LecturerId,
                ModuleId = lecturerModule.ModuleId
            };

            return lecturerModuleDto;
        }



        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<LecturerModuleDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var query = _repository.GetAllIncluding(m => m.Lecturer);
                var result = new PagedResultDto<LecturerModuleDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<LecturerModuleDto>>(query);
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

        public Task<LecturerModuleDto> UpdateAsync(LecturerModuleDto input)
        {
            throw new NotImplementedException();
        }
    }
}

