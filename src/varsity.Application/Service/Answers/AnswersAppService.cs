using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Domain.Enums;
using varsity.Service.Dto_s;

namespace varsity.Service.Answers
{
    public class AnswersAppService : ApplicationService, IAnswerAppService
    {

        private readonly IRepository<Answer, Guid> _repository;
        private readonly IRepository<Person, Guid> _person;
        private readonly IRepository<Question, Guid> _question;
        private readonly IRepository<Rating, Guid> _rating;

        public AnswersAppService(IRepository<Answer, Guid> repository, IRepository<Person, Guid> person , IRepository<Question, Guid> question, IRepository<Rating, Guid> rating)
        {
            _repository = repository;
            _person = person;
            _question = question;
            _rating = rating;
        }

        public async Task<AnswerDto> CreateAsync(AnswerDto input)
        {
            var userId = AbpSession.UserId;
            if (userId == null)
            {
                throw new ApplicationException("User invalid");
            }
            var person = await _person.FirstOrDefaultAsync(p => p.User.Id == userId);
            if (userId == null)
            {
                throw new ApplicationException("Person invalid");
            }

            var answer = ObjectMapper.Map<Answer>(input);
            answer.Person = await _person.GetAsync(person.Id);
            answer.Question = await _question.GetAsync((Guid)input.QuestionId);
            await _repository.InsertAsync(answer);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<AnswerDto>(answer);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        //public async Task<PagedResultDto<AnswerDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        //{
        //    try
        //    {
        //        var query = _repository.GetAllIncluding(m => m.Person, x => x.Question);
        //        var result = new PagedResultDto<AnswerDto>();
        //        result.TotalCount = query.Count();
        //        result.Items = ObjectMapper.Map<IReadOnlyList<AnswerDto>>(query);

        //        // Calculate rating count for each answer and adjust the total count
        //        foreach (var answerDto in result.Items)
        //        {
        //            var ratingCount = await GetRatingCountForAnswerAsync(answerDto.Id);

        //            // Adjust the total count based on the rating type
        //            if (answerDto.VoteType == RefListRate.RatingType2)
        //            {
        //                ratingCount -= 1;
        //            }
        //            else
        //            {
        //                ratingCount += 1;
        //            }

        //            answerDto.RatingCount = ratingCount;
        //        }

        //        return await Task.FromResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        public async Task<PagedResultDto<AnswerDto>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            try
            {
                var query = _repository.GetAllIncluding(m => m.Person, x => x.Question);
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

        //public async Task<List<AnswerDto>> GetByQuestionIdAsync(Guid questionId)
        //{
        //    var answers = await _repository
        //        .GetAllIncluding(p => p.Person, q => q.Question)
        //        .Where(a => a.Question.Id == questionId)
        //        .ToListAsync();

        //    return ObjectMapper.Map<List<AnswerDto>>(answers);
        //}

        public async Task<List<AnswerDto>> GetByQuestionIdAsync(Guid questionId)
        {
            var answers = await _repository
                .GetAllIncluding(p => p.Person, q => q.Question)
                .Where(a => a.Question.Id == questionId)
                .ToListAsync();

            var answerDtos = new List<AnswerDto>();

            foreach (var answer in answers)
            {
                var ratingCount = await GetRatingCountForAnswerAsync(answer.Id);
                var answerDto = ObjectMapper.Map<AnswerDto>(answer);
                answerDto.RatingCount = (long)ratingCount;
                answerDtos.Add(answerDto);
            }

            return answerDtos;
        }

        public async Task<double> GetRatingCountForAnswerAsync(Guid answerId)
        {
            var total = await _rating.CountAsync(r => r.Answer.Id == answerId);
            var countLikes = await _rating.CountAsync(r => r.Answer.Id == answerId && r.VoteType == RefListRate.like);
            var countDislikes = await _rating.CountAsync(r => r.Answer.Id == answerId && r.VoteType == RefListRate.dislike);

            // Calculate the average
            double averageRating = (double)countLikes / (countLikes + countDislikes);

            // Round the average rating to the nearest whole number
            int roundedRating = (int)Math.Round(averageRating);

            total = countLikes - countDislikes;
            return total;
        }

        public async Task<AnswerDto> GetAnswerWithRatingsAsync(Guid id)
        {
            var answer = await _repository.GetAllIncluding(p => p.Person, q => q.Question)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (answer == null)
            {
                throw new Exception($"Answer with ID '{id}' not found.");
            }

            var ratingCount = await GetRatingCountForAnswerAsync(answer.Id);

            var answerDto = ObjectMapper.Map<AnswerDto>(answer);
            answerDto.RatingCount = (long)ratingCount;

            return answerDto;
        }
        public async Task UpdateAsync(AnswerDto input)
        {
            var answer = await _repository.GetAsync(input.Id);
            ObjectMapper.Map(input, answer);
            await _repository.UpdateAsync(answer);
            
            
        }



    }
}
