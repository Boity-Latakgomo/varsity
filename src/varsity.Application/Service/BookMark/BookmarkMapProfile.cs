using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.Dto_s;

namespace varsity.Service.BookMark
{
    public class BookmarkMappingProfile : Profile
    {
        public BookmarkMappingProfile()
        {
            CreateMap<Bookmark, BookmarkDto>()
                  .ForMember(e => e.QuestionId, m => m.MapFrom(e => e.Question != null ? e.Question.Id : (Guid?)null))
                  .ForMember(e => e.PersonId, m => m.MapFrom(e => e.Person != null ? e.Person.Id : (Guid?)null))
                  .ForMember(e => e.AnswerId, m => m.MapFrom(e => e.Answer != null ? e.Answer.Id : (Guid?)null))
                  .ForMember(e => e.AnswerText, m => m.MapFrom(e => e.Answer != null ? e.Answer.Text : null))
                  .ForMember(e => e.AnswerQuestionText, m => m.MapFrom(e => e.Answer.Question != null ? e.Answer.Question.Text : null))
                  .ForMember(e => e.QuestionText, m => m.MapFrom(e => e.Question != null ? e.Question.Text : null));

            CreateMap<BookmarkDto, Bookmark>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
