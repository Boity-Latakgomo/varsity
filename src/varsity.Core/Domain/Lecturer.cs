using varsity.Domain.Antributes;

namespace varsity.Domain
{
    [Entity(TypeShortAlias = "Arf.Lecture")]
    [DiscriminatorValue("Arf.Lecture")]
    public class Lecturer : Person
    {
        
    }
}
