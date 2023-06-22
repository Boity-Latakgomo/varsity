using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Authorization.Users;
using varsity.Domain;
using varsity.Service.Dto_s;
using varsity.Service.Students;

namespace varsity.Service.Student_s
{
    public class StudentMapProfile : Profile
    {
        public StudentMapProfile()
        {
            CreateMap<Student, StudentOutputDto>()
                .ForMember(x => x.UserName, m => m.MapFrom(x => x.User != null ? x.User.UserName :null))
                .ForMember(x => x.CourseId, m => m.MapFrom(x => x.Course != null ? x.Course.Id : (Guid?)null));

            CreateMap<StudentDto, User>()
                .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
                .ForMember(x => x.PhoneNumber, m => m.MapFrom(x => x.PhoneNumber))
                .ForMember(x => x.EmailAddress, m => m.MapFrom(x => x.EmailAddress))
                .ForMember(x => x.FullName, m => m.MapFrom(x => x.Name + " " + x.Surname))
                .ForMember(x => x.Password, m => m.MapFrom(x => x.Password))
                .ForMember(x => x.Surname, m => m.MapFrom(x => x.Surname))
                .ForMember(x => x.UserName, m => m.MapFrom(x => x.Name + x.Surname.Substring(0, 4)));

            CreateMap<StudentDto, User>()
                .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<StudentDto, Student>()
                .ForMember(e => e.Id, d => d.Ignore());

        }
    }
}
