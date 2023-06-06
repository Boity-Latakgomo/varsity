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
using varsity.Service.Course_s;
using varsity.Service.Dto_s;
using Microsoft.EntityFrameworkCore;

namespace varsity.Service.Modules
{
    public class ModuleAppService : ApplicationService, IModuleAppService
    {

        private readonly IRepository<Module, Guid> _repository;
        private readonly IRepository<Course, Guid> _course;
        private readonly Module module;

        public ModuleAppService(IRepository<Module, Guid> repository, IRepository<Course, Guid> course)
        {
            _repository = repository;
            _course = course;
        }


        public async Task<ModuleDto> CreateAsync(ModuleDto input)
        {
            var course = ObjectMapper.Map<Module>(input);
            course.Course = await _course.GetAsync((Guid)input.CourseId);
            await _repository.InsertAsync(module);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<ModuleDto>(module);
        }



        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<ModuleDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var query = _repository.GetAllIncluding(m => m.Course);
                var result = new PagedResultDto<ModuleDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<ModuleDto>>(query);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ModuleDto> GetAsync(Guid id)
        {
            var module = await _repository.GetAllIncluding(c => c.Course).FirstOrDefaultAsync(c => c.Id == id);//we want a course associated with its department by course id
            if (module == null)
            {
                throw new Exception($"Course with ID '{id}' not found.");
            }

            return ObjectMapper.Map<ModuleDto>(module);
        }

        public Task<ModuleDto> UpdateAsync(ModuleDto input)
        {
            throw new NotImplementedException();
        }
    }
}
