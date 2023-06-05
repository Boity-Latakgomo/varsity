using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;

namespace varsity.Service.Dto_s
{
    public class ModuleStudent: EntityDto<Guid>
    {
        public Guid? StudentId { get; set; }
        public Guid? ModuleId { get; set; }
    }
}
