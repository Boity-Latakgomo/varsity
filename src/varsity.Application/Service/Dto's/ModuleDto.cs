using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Service.Dto_s
{
    [AutoMap(typeof(Module))]
    //ABP will map Name and code but not CourseId bcos ABP Automap Dsnt map foreign keys
    public class ModuleDto: EntityDto<Guid>
    {
        public Guid? CourseId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
