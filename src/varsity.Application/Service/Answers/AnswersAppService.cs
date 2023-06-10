using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.Dto_s;

namespace varsity.Service.Answers
{
    public class AnswersAppService : ApplicationService, IAnswerAppService
    {

        private readonly IRepository<Answer, Guid> _repository;
        private readonly IRepository<Person, Guid> _person;
        private readonly IRepository<Question, Guid> _question;

        public AnswersAppService(IRepository<Answer, Guid> repository, IRepository<Person, Guid> person , IRepository<Question, Guid> question)
        {
            _repository = repository;
            _person = person;
            _question = question;
        }

        public async Task<AnswerDto> CreateAsync(AnswerDto input)
        {
            var answer = ObjectMapper.Map<Answer>(input);
            answer.Person = await _person.GetAsync((Guid)input.PersonId);
            answer.Question = await _question.GetAsync((Guid)input.QuestionId);
            await _repository.InsertAsync(answer);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<AnswerDto>(answer);
        }



        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<AnswerDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var query = _repository.GetAllIncluding(m => m.Person, x=> x.Question);
                var result = new PagedResultDto<AnswerDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<AnswerDto>>(query);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<AnswerDto> GetAsync(Guid id)
        {
            var answers =  await _repository.GetAllIncluding(p => p.Person, q => q.Question).Where(a => a.Id == id).FirstOrDefaultAsync();
            if (answers == null)
            {
                throw new Exception($"Answer with ID '{id}' not found.");
            }

            return ObjectMapper.Map<AnswerDto>(answers);
        }

        public async Task<List<AnswerDto>> GetByQuestionIdAsync(Guid questionId)
        {
            var answers = await _repository
                .GetAllIncluding(p => p.Person, q => q.Question)
                .Where(a => a.Question.Id == questionId)
                .ToListAsync();

            return ObjectMapper.Map<List<AnswerDto>>(answers);
        }


        public Task<AnswerDto> UpdateAsync(AnswerDto input)
        {
            throw new NotImplementedException();
        }
    }
}
