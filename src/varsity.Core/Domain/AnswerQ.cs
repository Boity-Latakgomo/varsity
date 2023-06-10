using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Domain
{
    public class AnswerQ : FullAuditedEntity<Guid>
    {
        public virtual Question Question { get; set; }
        public virtual string Text { get; set; }
        public virtual Person? Person { get; set; }
        public virtual Guid PersonId { get; set; }
        public virtual Guid QuestionId { get; set; }
    }
}
