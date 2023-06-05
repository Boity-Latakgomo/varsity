using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Domain.Antributes
{
    public class DiscriminatorAttribute : Attribute

    {
        //Name of the DiscriminatorColumn used in object relational mapping(ORM)to map a hierarchy of objects to a relational database table.
        //Used to specify the name of the discriminator column tht wl be used to determine the type of an entity in a database table'
        public string DiscriminatorColumn { get; set; }

        //If true,We can be able to use the discriminator values that we have there.
        //it indicates that entity uses discriminator,if its false everything will just be the same
        public bool UseDiscriminator { get; set; }

        //This property is used to indicate whether to filter out entities that have unknown discriminator values.
        //If true, entities with unknown discriminator values will not be returned when querying the database.
        //If false, entities with unknown discriminator values will be returned when querying the database.
        public bool FilterUnknownDiscriminators { get; set; }


        //constructor for a class  DiscriminatorAttribute,it initiates three properties below(DiscriminatorColumn, UseDiscriminator,FilterUnknownDiscriminators)
        public DiscriminatorAttribute()
        {
            DiscriminatorColumn = "Frwk_Discriminator";
            UseDiscriminator = true;//UseDiscriminator property is set to true, indicating that the DiscriminatorColumn should be used to determine the type of an entity in a table.
            FilterUnknownDiscriminators = false;
        }




    }
}

