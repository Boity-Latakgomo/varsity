using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class StudentAppService:ApplicationService, IStudentAppService
    {
        private readonly IRepository<Student, Guid> _studentRepository;
        private readonly IRepository<Course, Guid> _courseRepository;
        private readonly IRepository<StudentPool, Guid> _studentPoolRepository;
        private readonly UserManager _userManager;

        public StudentAppService(IRepository<Student, Guid> studentRepository, UserManager userManager, IRepository<Course, Guid> courseRepository, IRepository<StudentPool, Guid> studentPoolRepository)
        {
            _studentRepository = studentRepository;
            _userManager = userManager;
            _studentPoolRepository = studentPoolRepository;
            _courseRepository = courseRepository;
        }

        public async Task<StudentDto> CreateAsync(StudentDto input)
        {
            var specificStudent =  _studentPoolRepository.FirstOrDefault(s => s.StudentNumber == input.UserName);

            if (specificStudent == null)
            {
                throw new ApplicationException("student not found");
            }

            var student = ObjectMapper.Map<Student>(input);

            student.User = await CreateUser(input);//creating a user before creating a student
            student.Course = await _courseRepository.GetAsync(input.CourseId);
            

            return ObjectMapper.Map<StudentDto>( await _studentRepository.InsertAsync(student));
        }

        public async Task<StudentOutputDto> GetStudentLoggedInAsync()
        {
            var userId = AbpSession.UserId;
            if (userId == null)
            {
                throw new ApplicationException("User not logged in");
            }

            var student = await _studentRepository.GetAllIncluding(s => s.Course, u => u.User).FirstOrDefaultAsync(s => s.User.Id == userId);

            if (student == null)
            {
                throw new ApplicationException("Student not found");
            }


            var course = await _courseRepository.FirstOrDefaultAsync(student.Course.Id);
            if (course == null)
            {
                throw new ApplicationException("Course not found");
            }

            var studentOutputDto = ObjectMapper.Map<StudentOutputDto>(student);
            studentOutputDto.CourseId = course.Id;

            return studentOutputDto;
        }

        private async Task<User> CreateUser(StudentDto input)
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
 