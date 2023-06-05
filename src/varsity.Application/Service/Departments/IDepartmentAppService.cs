using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;

namespace varsity.Service
{
    public interface IDepartmentAppService : IAsyncCrudAppService<DepartmentDto, Guid, PagedAndSortedResultRequestDto>
    {
        
    }
}
