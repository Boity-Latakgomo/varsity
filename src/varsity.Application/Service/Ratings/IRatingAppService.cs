using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;

namespace varsity.Service.Ratings
{
    public interface IRatingAppService : IApplicationService
    {
        Task<RatingDto> CreateAsync(RatingDto input);
        Task<RatingDto> UpdateAsync(RatingDto input);
        Task<PagedResultDto<RatingDto>> GetAllAsync(PagedAndSortedResultRequestDto input);

    }
}

