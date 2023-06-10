using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;

namespace varsity.Service.Dto_s
{
    [AutoMap(typeof(Question))]
    public class QuestionDto: EntityDto<Guid>
    {
        public string Text { get; set; }
        public string Title { get; set; }
        public Guid? PersonId { get; set; }
        public Guid? ModuleId { get; set; }

    }
}
