using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Service.Dto_s;

namespace varsity.Service.BookMark
{ 
 public interface IBookmarkAppService : IApplicationService
{

        public Task<BookmarkDto> AddBookMark(BookmarkDto input);
        public Task<List<BookmarkDto>> GetAllBookmarkAsync(Guid PersonId);
        public Task DeleteBookmark(Guid BookmarkId);


}
}
