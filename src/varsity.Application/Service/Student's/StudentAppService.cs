using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;
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
    public class StudentAppService:ApplicationService, IStudentAppService
    {
        private readonly IRepository<Student, Guid> _studentRepository;
        private readonly UserManager _userManager;

        public StudentAppService(IRepository<Student, Guid> studentRepository, UserManager userManager)
        {
            _studentRepository = studentRepository;
            _userManager = userManager;
        }

        public async Task<StudentDto> CreateAsync(StudentDto input)
        {
            var person = ObjectMapper.Map<Student>(input);
            person.User = await CreateUser(input);//creating a user before creating a person
            return ObjectMapper.Map<StudentDto>(
                await _studentRepository.InsertAsync(person));
        }

        private async Task<User> CreateUser(PersonDto input)
        {
            var user = ObjectMapper.Map<User>(input);
            ObjectMapper.Map(input, user);
            if (!string.IsNullOrEmpty(user.NormalizedUserName) && !string.IsNullOrEmpty(user.NormalizedEmailAddress))
                user.SetNormalizedNames();
            user.TenantId = AbpSession.TenantId;
            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);
            CheckErrors(await _userManager.CreateAsync(user, input.Password));
            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRolesAsync(user, input.RoleNames));
            }

            CurrentUnitOfWork.SaveChanges();
            return user;
        }
        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

    }
}
 