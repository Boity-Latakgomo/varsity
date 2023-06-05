using System;

namespace varsity.Domain
{
    internal class EntityAttribute : Attribute
    {
        public string TypeShortAlias { get; set; }
    }
}