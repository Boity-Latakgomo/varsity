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

namespace varsity.Service.Questions
{
    public class QuestionAppService : ApplicationService, IQuestionAppService
    {

        private readonly IRepository<   Question, Guid> _repository;
        private readonly IRepository<Person, Guid> _person;

        public QuestionAppService(IRepository<Question, Guid> repository, IRepository<Person, Guid> person)
        {
            _repository = repository;
            _person = person;
        }



        public async Task<QuestionDto> CreateAsync(QuestionDto input)
        {
            var question = ObjectMapper.Map<Question>(input);
            question.Person = await _person.GetAsync((Guid)input.PersonId);
            await _repository.InsertAsync(question);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<QuestionDto>(question);
        }



        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<QuestionDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var query = _repository.GetAllIncluding(m => m.Person);
                var result = new PagedResultDto<QuestionDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<QuestionDto>>(query);
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

        public Task<QuestionDto> UpdateAsync(QuestionDto input)
        {
            throw new NotImplementedException();
        }
    }
}

