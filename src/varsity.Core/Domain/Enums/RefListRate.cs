using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace varsity.Domain.Enums
{
    public enum RefListRate : int
    {
        [Description("1. like")]
        like = 1,

        [Description("2. dislike")]
        dislike = 2,
    }
}
