using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dtos;

namespace varsity.Service.LecturerPoolService
{
    public interface ILecturerPoolAppService: IApplicationService
   
        {
            Task<LecturerPoolDto> CreateAsync(LecturerPoolDto input);

        }
    }

