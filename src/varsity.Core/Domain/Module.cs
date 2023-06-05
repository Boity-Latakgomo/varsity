using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Domain
{
    [Entity(TypeShortAlias = "Arf.Module")]
    public class Module : FullAuditedEntity<Guid>
    {
        public virtual Course Course { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
    }
}
