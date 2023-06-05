using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Domain.Antributes
{
    public class EntityAntribute : Attribute
    {
        //specifies which name entity should be shown in the table when required
        //this is actually where we define a domain for it
        public string FriendlyName { get; set; }
        //This is a short version of the type name of the entity class that is unique within all the entities in the current solution.
        //This means that the TypeShortAlias property can be used to identify the entity class in a more concise way than using the full type name.
        public string TypeShortAlias { get; set; }
    }
}
