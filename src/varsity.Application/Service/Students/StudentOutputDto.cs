using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.Dto_s;
using varsity.Service.Persons;

namespace varsity.Service.Students
{
    [AutoMap(typeof(Student))]
    public class StudentOutputDto : PersonOutputDto
    {
        public Guid CourseId { get; set; }
        public int AcademicYear { get; set; }
    }
}
