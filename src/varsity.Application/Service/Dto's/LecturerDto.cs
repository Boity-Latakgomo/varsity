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
    [AutoMap(typeof(Lecturer))]
    public class LecturerDto: EntityDto<Guid>
    {
        public string LecturerNumber { get; set; }

        // public virtual string EmployeeName { get; set;}
        public string Qualification { get; set; }
    }
}
