﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Domain
{
    [Entity(TypeShortAlias = "Arf.ModuleStudent")]
    public class ModuleStudent: FullAuditedEntity<Guid>
    {
        public virtual Student Student { get; set; }
        public virtual Module Module { get; set; }
        public virtual Guid StudentId { get; set; }
        public virtual Guid ModuleId { get; set; }
    }
}
