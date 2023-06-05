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
    [AutoMap(typeof(Course))]
    public class CourseDto: EntityDto<Guid>
    {
        public string Name { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
