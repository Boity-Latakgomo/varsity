using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Domain
{
    public class LecturerModule: FullAuditedEntity<Guid>
    {
        //this is a foreign key from table of Lecture's
        public virtual Lecturer Lecturer { get; set; }

        public virtual Lecturer Module { get; set; }
    }
}
