using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Domain
{
    [Entity(TypeShortAlias = "Arf.RegisterModule")]
    public class RegisterModule: FullAuditedEntity<Guid>
    {
        public virtual Student Student { get; set; }
        public virtual Module Module { get; set; }
    }
}
