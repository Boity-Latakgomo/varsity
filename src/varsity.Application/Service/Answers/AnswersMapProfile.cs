using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.Dto_s;

namespace varsity.Service.Answers
{
    public class AnswersMapProfile : Profile
    {
        public AnswersMapProfile()
        {
            CreateMap<Answer, AnswerDto>()
                  //we first check if Department in Course is not null. If not null we assign Department.Id to DepartmentId in Course.
                  //else its gonna return 000...if its null instead of breaking
                  .ForMember(e => e.PersonId, m => m.MapFrom(e => e.Person != null ? e.Person.Id : (Guid?)null))
                  .ForMember(e => e.QuestionId, m => m.MapFrom(e => e.Question != null ? e.Question.Id : (Guid?)null));

            //ignoring any types of id so there wont be any issues or break during your host when fetching data from the Db
            CreateMap<AnswerDto, Answer>()
                .ForMember(e => e.Id, d => d.Ignore());
        }

    }
}