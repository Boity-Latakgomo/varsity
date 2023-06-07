using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain.Enums;

namespace varsity.Domain
{
    public class Rating: FullAuditedEntity<Guid>
    {
        public virtual RefListRate? VoteType { get; set; }
        public virtual Question Question { get; set; }
        public virtual Person Person { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
