using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using varsity.Authorization.Users;

namespace varsity.Domain
{
    public class Person: FullAuditedEntity<Guid>
    {
        [Required]
        public virtual string UserName { get; set; }
        public virtual string Name{ get; set; }
        public virtual string Surname { get; set; }
        public virtual string IdentificationNumber  { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string Password { get; set; }
        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
        
        [NotMapped]
        public virtual string[] RoleNames { get; set; }
    }
}
  