using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.Dtos;

namespace varsity.Service.LecturerPoolService
{
    public class LecturerPoolAppService:ApplicationService,ILecturerPoolAppService
    {
        private readonly IRepository<LecturerPool, Guid> _repository;

        public LecturerPoolAppService(IRepository<LecturerPool, Guid> repository )
        {
            _repository = repository;
            
        }

        public async Task<LecturerPoolDto> CreateAsync(LecturerPoolDto input)
        {
            return ObjectMapper.Map<LecturerPoolDto>(await _repository.InsertAsync(ObjectMapper.Map<LecturerPool>(input)));
        }
    }
}
