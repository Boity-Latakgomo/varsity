using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;

namespace varsity.Service.StoredFileService.Dto
{
    [AutoMap(typeof(StoredFile))]
    public class StoredFileDto : FullAuditedEntityDto<Guid?>
    {
        public IFormFile File { get; set; }
        public Byte[] Data { get; set; }
        public Guid LecturerId { get; set; }
        public string Name { get; set; }
        public string LectureName { get; set; }
    }
}
