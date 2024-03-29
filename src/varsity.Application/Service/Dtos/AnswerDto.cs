﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;

namespace varsity.Service.Dto_s
{
    [AutoMap(typeof(Answer))]
    public class AnswerDto: FullAuditedEntityDto<Guid>
    {
        public Guid? QuestionId { get; set; }
        public string Text { get; set; }
        public Guid? PersonId { get; set; }
        public string PersonName { get; set; }
        public string QuestionText { get; set; }
        public long RatingCount { get; set; }


    }
}
