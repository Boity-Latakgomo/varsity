using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;

namespace varsity.Service.Person_s
{
        public interface IPersonAppService : IApplicationService
        {
            Task<PersonDto> CreateAsync(PersonDto input);
            Task<PersonDto> GetAsync(Guid id);
            Task<List<PersonDto>> GetAllAsync();
            Task<PersonDto> UpdateAsync(PersonDto input);
            Task Delete(Guid id);
        }
}
