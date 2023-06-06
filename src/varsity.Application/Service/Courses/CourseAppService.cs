using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.Dto_s;

namespace varsity.Service.Course_s
{
    public class CourseAppService : ApplicationService, ICourseAppService
    {

        private readonly IRepository<Course, Guid> _repository;
        private readonly IRepository<Department, Guid> _department;

        public CourseAppService(IRepository<Course, Guid> repository, IRepository<Department , Guid> department)
        {
            _repository = repository;
            _department = department;
        }


        public  async Task<CourseDto> CreateAsync(CourseDto input)
        {
           var course = ObjectMapper.Map<Course>(input);
            course.Department = await _department.GetAsync((Guid)input.DepartmentId);
            await _repository.InsertAsync(course);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<CourseDto>(course);
        }



        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<CourseDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var query = _repository.GetAllIncluding(m => m.Department);
                var result = new PagedResultDto<CourseDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<CourseDto>>(query);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<CourseDto> GetAsync(Guid id)
        {
            var course = await _repository.GetAllIncluding(c => c.Department).FirstOrDefaultAsync(c => c.Id == id);//we want a course associated with its department by course id
            if (course == null)
            {
                throw new Exception($"Course with ID '{id}' not found.");
            }

            return  ObjectMapper.Map<CourseDto>(course);
        }

        public Task<CourseDto> UpdateAsync(CourseDto input)
        {
            throw new NotImplementedException();
        }
    }
}
