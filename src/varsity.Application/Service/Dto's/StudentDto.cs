using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Service.Dto_s
{
    public class StudentDto : EntityDto<Guid> 
    {
        public string StudentNumber { get; set; }
        public Guid? CourseId { get; set; }
        public int AcademicYear { get; set; }
    }
}
