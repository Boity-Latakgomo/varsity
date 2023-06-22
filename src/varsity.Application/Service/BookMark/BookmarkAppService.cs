using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Domain.Enums;
using varsity.Service.Dto_s;

namespace varsity.Service.BookMark
{
    public class BookmarkService : ApplicationService, IBookmarkAppService
    {
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IRepository<Answer, Guid> _answerRepository;
        private readonly IRepository<Question, Guid> _questionRepository;
        private readonly IRepository<Bookmark, Guid> _bookmarkRepository;

        public BookmarkService(IRepository<Person, Guid> personRepository, IRepository<Answer, Guid> answerRepository, IRepository<Bookmark, Guid> bookmarkRepository, IRepository<Question, Guid> questionRepository)
        {
            _personRepository = personRepository;
            _answerRepository = answerRepository;
            _bookmarkRepository = bookmarkRepository;
            _questionRepository = questionRepository;
        }

        [HttpPost]
        public async Task<BookmarkDto> AddBookMark(BookmarkDto input)
        {
            var person = await _personRepository.GetAsync(input.PersonId);

            if (person == null) throw new ApplicationException("Person not found.");
            var bookmark = ObjectMapper.Map<Bookmark>(input);
            bookmark.Person = person;
            if (input.Type == RefListBookmarkType.question)
            {
                bookmark.Question = await _questionRepository.GetAsync(input.QuestionId);
            } else
            {
                bookmark.Answer = await _answerRepository.GetAsync(input.AnswerId);
            }

            return ObjectMapper.Map<BookmarkDto>(await _bookmarkRepository.InsertAsync(bookmark));
        }

        [HttpGet]
        public async Task<List<BookmarkDto>> GetAllBookmarkAsync(Guid PersonId)
        {
            var bookmarks = await _bookmarkRepository
        .GetAll()
        .Include(b => b.Person)
        .Include(b => b.Answer)
            .ThenInclude(a => a.Question)
        .Where(b => b.Person.Id == PersonId)
        .ToListAsync();

            var bookmarkDtos = ObjectMapper.Map<List<BookmarkDto>>(bookmarks);
            return bookmarkDtos;
        }

        [HttpDelete]
        public async Task DeleteBookmark(Guid BookmarkId)
        {
            await _bookmarkRepository.DeleteAsync(BookmarkId);
        }


    }
}
