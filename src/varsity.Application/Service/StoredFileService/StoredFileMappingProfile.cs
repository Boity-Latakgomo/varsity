using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.StoredFileService.Dto;

namespace varsity.Service.StoredFileService
{
    public class StoredFileMappingProfile: Profile
    {
        public StoredFileMappingProfile()
        {
            CreateMap<StoredFile, StoredFileDto>()
                .ForMember(x=> x.LecturerId, v => v.MapFrom(c=> c.Lecturer.Id))
                .ForMember(x => x.LectureName, v => v.MapFrom(c => c.Lecturer.Name));
        }
    }
}
