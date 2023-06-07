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
using varsity.Service.Answers;
using varsity.Service.Dto_s;

namespace varsity.Service.Ratings
{
    public class RatingAppService : ApplicationService, IRatingAppService
    {

        private readonly IRepository<Rating, Guid> _repository;
        private readonly IRepository<Person, Guid> _person;
        private readonly IRepository<Question, Guid> _question;
        private readonly IRepository<Answer, Guid> _answer;

        public RatingAppService(IRepository<Rating, Guid> repository, IRepository<Person, Guid> person, IRepository<Question, Guid> question, IRepository<Answer, Guid> answer)
        {
            _repository = repository;
            _person = person;
            _question = question;
            _answer = answer;
        }

        public async Task<RatingDto> CreateAsync(RatingDto input)
        {
            var rating = ObjectMapper.Map<Rating>(input);
            rating.Person = await _person.GetAsync((Guid)input.PersonId);
            rating.Answer = await _answer.GetAsync((Guid)input.AnswerId);
            await _repository.InsertAsync(rating);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<RatingDto>(rating);
        }

        public async Task<PagedResultDto<RatingDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var query = _repository.GetAll();
                var result = new PagedResultDto<RatingDto>();
                result.TotalCount = query.Count();
                result.Items = ObjectMapper.Map<IReadOnlyList<RatingDto>>(query);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<RatingDto> UpdateAsync(RatingDto input)
        {
            var rate = await _repository.GetAsync(input.Id);
            ObjectMapper.Map(input, rate);
            return ObjectMapper.Map<RatingDto>(input);
        }
    }
}

