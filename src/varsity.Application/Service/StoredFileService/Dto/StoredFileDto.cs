using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using varsity.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeForHope.Services.StoredFileService.Dto
{
    [AutoMap(typeof(StoredFile))]
    public class StoredFileDto : EntityDto<Guid?>
    {
        public IFormFile File { get; set; }
    }
}
