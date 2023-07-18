using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using varsity.Authorization.Users;
using varsity.Domain;
using varsity.Service.Dto_s;
using varsity.Service.Persons;
using varsity.Service.Students;

namespace varsity.Service.Person_s
{
    public class PersonAppService : ApplicationService, IPersonAppService
    {
        //Repositories 
        private readonly IRepository<Person, Guid> _PersonRepository;
        private readonly IRepository<Course, Guid> _CourseRepository;
        private readonly UserManager _userManager;
        //Dependency Injection
        public PersonAppService(IRepository<Person, Guid> personRepository, UserManager userManager, IRepository<Course, Guid> courseRepository)
        {
            _PersonRepository = personRepository;
            _userManager = userManager;
            _CourseRepository = courseRepository;
        }
        //Your Custom Methods
        [HttpPost]
        public async Task<PersonDto> CreateAsync(PersonDto input)
        {
            var person = ObjectMapper.Map<Person>(input);
            person.User = await CreateUser(input);
            return ObjectMapper.Map<PersonDto>( await _PersonRepository.InsertAsync(person));
        }
        [HttpGet]
        public async Task<List<PersonDto>> GetAllAsync()
        {
            var query = _PersonRepository.GetAllIncluding(m => m.User, c => c.Course).ToList();
            return ObjectMapper.Map<List<PersonDto>>(query);
        }
        [HttpGet]
        public async Task<PersonDto> GetAsync(Guid id)
        {          
            var query = _PersonRepository.GetAllIncluding(m => m.User).FirstOrDefault(x => x.Id == id);
            return ObjectMapper.Map<PersonDto>(query);
        }
        [HttpPut]
        public async Task<PersonDto> UpdateAsync(PersonDto input)
        {
            var person = _PersonRepository.Get(input.Id);
            var updt = await _PersonRepository.UpdateAsync(ObjectMapper.Map(input, person));
            return ObjectMapper.Map<PersonDto>(updt);
        }
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _PersonRepository.DeleteAsync(id);
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

        public async Task<PersonDto> GetAsyncPerson(long id)
        {
            var person = _PersonRepository.FirstOrDefault(p => p.User.Id == id);
            if (person == null)
            {
                return null;
            }

            return ObjectMapper.Map<PersonDto>(person);
        }

        [HttpGet]
        public async Task<PersonDto> GetPersonAsync(long id)
        {
            var query = _PersonRepository.GetAllIncluding(m => m.User).FirstOrDefault(x => x.User.Id == id);
            return ObjectMapper.Map<PersonDto>(query);
        }

        public async Task<PersonOutputDto> GetPersonLoggedInAsync()
        {
            var userId = AbpSession.UserId;
            if (userId == null)
            {
                throw new ApplicationException("User not logged in");
            }
            //Get a person based onn the user Id. Include the course
            var person = await _PersonRepository.GetAllIncluding(s => s.Course, u => u.User).FirstOrDefaultAsync(s => s.User.Id == userId);
            if (person == null)
            {
                throw new ApplicationException("Person not found");
            }

            var result = ObjectMapper.Map<PersonOutputDto>(person);

            return  result;
        }

    }
}
