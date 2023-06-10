using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.Dto_s;

namespace varsity.Service.Questions
{
    [AutoMap(typeof(Question))]
    public class QuestionListAnswerDto : EntityDto<Guid>
    {
        public string SearchTerm { get; set; }
        public Guid ModuleId { get; set; }

        public List<AnswerDto> AnswerDtos { get; set; }
    }
}
