using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Domain
{
    public class Question: FullAuditedEntity<Guid>
    {
        public virtual string Text { get; set; }
        public virtual string Title { get; set; }
        public virtual Person Person { get; set; }
        public virtual Module? Module { get; set; }
    }
}
