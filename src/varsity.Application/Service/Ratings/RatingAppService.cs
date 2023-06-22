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
using Microsoft.EntityFrameworkCore;

namespace varsity.Service.Ratings
{
    public class RatingAppService : ApplicationService, IRatingAppService
    {

        private readonly IRepository<Rating, Guid> _repository;
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IRepository<Question, Guid> _questionRepository;
        private readonly IRepository<Answer, Guid> _answerRepository;

        public RatingAppService(IRepository<Rating, Guid> repository, IRepository<Person, Guid> person, IRepository<Question, Guid> question, IRepository<Answer, Guid> answerRepository)
        {
            _repository = repository;
            _personRepository = person;
            _questionRepository = question;
            _answerRepository = answerRepository;
        }

        public async Task<RatingDto> CreateAsync(RatingDto input)
        {
            var user = AbpSession;
            if (user == null)
            {
            }
            var person = await _personRepository.GetAllIncluding(m => m.User).FirstOrDefaultAsync(x => x.User.Id == user.UserId);

            var rating = ObjectMapper.Map<Rating>(input);
            rating.Person = await _personRepository.GetAsync(person.Id);
            rating.Answer = await _answerRepository.GetAsync((Guid)input.AnswerId);
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

