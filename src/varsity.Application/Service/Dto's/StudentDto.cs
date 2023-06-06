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
    [AutoMap(typeof(Student))]
    public class StudentDto : PersonDto
    {
        public string StudentNumber { get; set; }
        public Guid? CourseId { get; set; }
        public int AcademicYear { get; set; }
    }
}
