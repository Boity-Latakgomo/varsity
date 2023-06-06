using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.Dto_s;

namespace varsity.Service.LectureModule
{
    public class LecturerModuleMapProfile : Profile
    {
        public LecturerModuleMapProfile()
        {
            CreateMap<LecturerModule, LecturerModuleDto>()
                  //we first check if Department in Course is not null. If not null we assign Department.Id to DepartmentId in Course.
                  //else its gonna return 000...if its null instead of breaking
                  .ForMember(e => e.LecturerId, m => m.MapFrom(e => e.Lecturer != null ? e.Lecturer.Id : (Guid?)null))
                  .ForMember(e => e.ModuleId, m => m.MapFrom(e => e.Module != null ? e.Module.Id : (Guid?)null));

            //ignoring any types of id so there wont be any issues or break during your host when fetching data from the Db
            CreateMap<LecturerModuleDto, LecturerModule>()
                .ForMember(e => e.Id, d => d.Ignore());
        }

    }
}
