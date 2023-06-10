using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;

namespace varsity.Service.Questions
{
    [AutoMap(typeof(Question))]
    public class QuestionSearchDto : EntityDto<Guid>
    {
        public string SearchTerm { get; set; }
        public Guid ModuleId { get; set; }
    }
}
