using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain;
using varsity.Service.Dto_s;

namespace varsity.Service.BookMark
{
    public class BookmarkMappingProfile : Profile
    {
        public BookmarkMappingProfile()
        {
            CreateMap<BookmarkDto, Bookmark>()
                .ForMember(e => e.Id, d => d.Ignore());
        }
    }
}
