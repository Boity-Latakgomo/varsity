using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Domain.Antributes
{
    [AttributeUsage(AttributeTargets.Class)]
    //Discriminator class which inherits from Attribute
    //Attributes are classes defined from ABP
    public class DiscriminatorValueAttribute : Attribute
    {
        public object Value { get; set; }
        //this is the Value you gonna write your self like TypeShortAlias of Student,Lecture,or Employee

        public DiscriminatorValueAttribute(object value) 
        { 
         Value = value;
        }
    }
}
 