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
        //[description("1. male")]
        //male = 1,

        //[description("2. female")]
        //female = 2,

        //[description("0. unknown")]
        //notdisclosed = 0
        [Description("1. like")]
        like = 1,

        [Description("2. dislike")]
        dislike = 2,

    }
}
