using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Domain
{
    public class LecturerPool: FullAuditedEntity<Guid>
    {
        public virtual string LecturerNumber { get; set; }
    }
}
