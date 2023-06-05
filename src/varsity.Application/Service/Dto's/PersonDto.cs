using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using varsity.Domain;

namespace varsity.Service.Dto_s
{
    [AutoMap(typeof(Person))]
    public class PersonDto:EntityDto<Guid>
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string IdentificationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public  string Password { get; set; }
        public  long UserId { get; set; }
        public  string[] RoleNames { get; set; }
        //public RefListGender Gender { get; set; }


    }
}
