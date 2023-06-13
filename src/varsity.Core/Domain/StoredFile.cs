using Abp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using varsity.Domain;
using Abp.Domain.Entities.Auditing;

namespace varsity.Domain
{
    public class StoredFile : FullAuditedEntity<Guid>
    {
        
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string FileType { get; set; }
        public virtual Byte[] Data { get; set; }

        public virtual Lecturer Lecturer { get; set; }
    }

}




