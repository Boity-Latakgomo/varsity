using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.Dto_s;

namespace varsity.Service
{
   public class DepartmentAppService : AsyncCrudAppService<Department, DepartmentDto, Guid, PagedAndSortedResultRequestDto>, IDepartmentAppService
    {
        private readonly IRepository<Department, Guid> _repository;
        public DepartmentAppService(IRepository<Department, Guid> repository):base(repository)
        {
            _repository = repository;
        }
    }
}
