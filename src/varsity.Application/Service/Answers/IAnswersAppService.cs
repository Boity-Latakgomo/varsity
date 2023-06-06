using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;

namespace varsity.Service.Answers
{
    public interface IAnswerAppService : IApplicationService
    {
        Task<AnswerDto> CreateAsync(AnswerDto input);
       Task<AnswerDto> UpdateAsync(AnswerDto input);
        Task<PagedResultDto<AnswerDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
        //Task<AnswerDto> GetAsync(Guid id);
       Task DeleteAsync(Guid id);

    }
}

