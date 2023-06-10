using Abp;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain.Enums;

namespace varsity.Domain
{
    public class Bookmark:FullAuditedEntity<Guid>

    {
        public virtual Person Person { get; set; }
        public virtual Question Question { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual RefListBookmarkType Type { get; set; }

        //public virtual Guid AnswerId { get; set; }
        //public virtual Guid PersonId { get; set; }
        //public virtual Guid QuestionId { get; set; }

    }
}
