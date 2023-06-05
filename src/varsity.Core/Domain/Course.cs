using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Domain
{
    [Entity(TypeShortAlias = "Arf.Course")]
    public class Course : FullAuditedEntity<Guid>
    {

        public virtual string Name { get; set; }

        public virtual Department? Department { get; set; }
    }
}
