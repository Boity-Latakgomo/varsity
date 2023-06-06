using Abp.Application.Services.Dto;
using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;

namespace varsity.Service.Questions
{

    public interface IQuestionAppService : IApplicationService
        {
            Task<QuestionDto> CreateAsync(QuestionDto input);
            Task<QuestionDto> UpdateAsync(QuestionDto input);
            Task<PagedResultDto<QuestionDto>> GetAllAsync(PagedAndSortedResultRequestDto input);
            //Task<QuestionDto> GetAsync(Guid id);
            Task DeleteAsync(Guid id);

        }
    }


