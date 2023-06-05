using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Authorization.Users;
using varsity.Domain.Enums;

namespace varsity.Domain
{
    public class Person: FullAuditedEntity<Guid>
    {
        public virtual string UserName { get; set; }
        public virtual string Name{ get; set; }
        public virtual string Surname { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string IdentificationNumber  { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string Password { get; set; }

        //public virtual RefList Gender { get; set; }
        public virtual User User { get; set; }
        [NotMapped]
        public virtual string[] RoleNames { get; set; }
    }
}
  