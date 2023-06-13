using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;

namespace varsity.Service.Dtos
{
    [AutoMap(typeof(StudentPool))]
    public class StudentPoolDto:EntityDto<Guid>
    {
        public string StudentNumber { get; set; }
    }
}
