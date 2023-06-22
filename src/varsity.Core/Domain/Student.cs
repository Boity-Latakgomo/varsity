using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using varsity.Domain.Antributes;

namespace varsity.Domain
{
    [Entity(TypeShortAlias = "Arf.Employee")]
    [DiscriminatorValue("Arf.Employee")]
    public class Student : Person
    {
        public virtual Course Course { get; set;}
        public virtual int AcademicYear { get; set; }
    }
}
