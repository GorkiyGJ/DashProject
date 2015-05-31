using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DashProject.Api.Enum
{
    
    public enum X264Profile
    {
        high = 3, //default value since it is the first enumerator
        baseline = 1,
        main = 2
    }

    public enum X264ProfileLevel
    {
        l_4 = 12, //default value since it is the first enumerator
        l_1 = 1,
        l_1b = 2,
        l_1_1 = 3,
        l_1_2 = 4,
        l_1_3 = 5,
        l_2 = 6,
        l_2_1 = 7,
        l_2_2 = 8,
        l_3 = 9,
        l_3_1 = 10,
        l_3_2 = 11,
        l_4_1 = 13,
        l_4_2 = 14,
        l_5 = 15,
        l_5_1 = 16
    }
}
