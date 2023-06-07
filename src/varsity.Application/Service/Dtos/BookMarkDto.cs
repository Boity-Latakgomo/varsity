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
    [AutoMap(typeof(Bookmark))]
    public class BookmarkDto: EntityDto<Guid>
    {
        public Guid? PersonId { get; set; }
        public Guid? QuestionId { get; set; }
        public Guid? AnswerId { get; set; }
    }
}
