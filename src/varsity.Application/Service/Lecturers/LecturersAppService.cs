using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Runtime.Session;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Authorization.Users;
using varsity.Domain;
using varsity.Service.Dto_s;
using varsity.Service.Student_s;

namespace varsity.Service.Lecturers
{
    public class LecturerAppService : ApplicationService, ILecturersAppService
    {
        private readonly IRepository<Lecturer, Guid> _lecturerRepository;
        private readonly IRepository<Course, Guid> _courseRepository;
        private readonly IRepository<LecturerPool, Guid> _lecturerPoolRepository;
        private readonly UserManager _userManager;
        

        public LecturerAppService(IRepository<Lecturer, Guid> lecturerRepository, UserManager userManager, IRepository<LecturerPool, Guid> lecturerPoolRepository, IRepository<Course, Guid> courseRepository)
        {
            _lecturerRepository = lecturerRepository;
            _courseRepository = courseRepository;
            _lecturerPoolRepository = lecturerPoolRepository;
            _userManager = userManager;
            
        }

        public async Task<LecturerDto> CreateAsync(LecturerDto input)
        {
            var specificLecturer = _lecturerPoolRepository.FirstOrDefault(s => s.LecturerNumber == input.UserName);

            if (specificLecturer == null)
            {
                throw new ApplicationException("lecturer not found");
            }
            var lecturer = ObjectMapper.Map<Lecturer>(input);
            lecturer.User = await CreateUser(input);//creating a user before creating a student
            lecturer.Course = await _courseRepository.GetAsync(input.CourseId);
            return ObjectMapper.Map<LecturerDto>(await _lecturerRepository.InsertAsync(lecturer));
        }

        private async Task<User> CreateUser(LecturerDto input)
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

