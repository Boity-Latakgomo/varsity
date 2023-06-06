using varsity.Domain.Antributes;

namespace varsity.Domain
{
    [Entity(TypeShortAlias = "Arf.Lecture")]
    [DiscriminatorValue("Arf.Lecture")]
    public class Lecturer : Person
    {
        public virtual string LecturerNumber { get; set; }

       // public virtual string EmployeeName { get; set;}
       public virtual string Qualification { get; set; }

    }
}
