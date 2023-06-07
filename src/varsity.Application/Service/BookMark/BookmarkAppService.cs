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
using varsity.Service.Dto_s;

namespace varsity.Service.BookMark
{
    public class BookmarkService : ApplicationService, IBookmarkAppService
    {
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IRepository<Answer, Guid> _answerRepository;
        private readonly IRepository<Bookmark, Guid> _bookmarkRepository;

        public BookmarkService(IRepository<Person, Guid> personRepository, IRepository<Answer, Guid> answerRepository, IRepository<Bookmark, Guid> bookmarkRepository)
        {
            _personRepository = personRepository;
            _answerRepository = answerRepository;
            _bookmarkRepository = bookmarkRepository;
        }

        [HttpPost]
        public async Task AddBookMark(BookmarkDto input)
        {
            var person = await _personRepository.GetAsync((Guid)input.PersonId);
            var answer = await _answerRepository.GetAsync((Guid)input.AnswerId);
            if (person == null)
            {
                throw new ApplicationException("Person not found.");
            }

            if (answer == null)
            {
                throw new ApplicationException("Answer not found.");
            }

            var bookmark = new Bookmark
            {
                PersonId = person.Id,
                AnswerId = answer.Id
            };

            await _bookmarkRepository.InsertAsync(bookmark);
        }

        [HttpGet]
        public async Task<List<BookmarkDto>> GetAllBookmarkAsync(Guid PersonId)
        {
            var bookmarks = await _bookmarkRepository
        .GetAll()
        .Include(b => b.Person)
        .Include(b => b.Answer)
        .Where(b => b.PersonId == PersonId)
        .ToListAsync();

            var bookmarkDtos = ObjectMapper.Map<List<BookmarkDto>>(bookmarks);
            return bookmarkDtos;

        }

        [HttpDelete]
        public async Task DeleteBookmark(Guid BookmarkId)
        {

            var bookmarkSelected = await _bookmarkRepository.FirstOrDefaultAsync(pm => pm.Id == BookmarkId);

            if (bookmarkSelected != null)
            {
                await _bookmarkRepository.DeleteAsync(bookmarkSelected);
            }
            else
            {
                throw new ApplicationException("bookmarkSelected not found.");
            }
        }


    }
}
