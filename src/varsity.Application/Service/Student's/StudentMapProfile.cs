using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Authorization.Users;
using varsity.Domain;
using varsity.Service.Dto_s;

namespace varsity.Service.Student_s
{
    internal class StudentMapProfile : Profile
    {
        public StudentMapProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(x => x.UserId, m => m.MapFrom(x => x.User != null ? x.User.Id : (long?)null));

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
