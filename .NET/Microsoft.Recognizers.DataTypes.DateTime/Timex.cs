using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Recognizers.DataTypes.DateTime
{
    public class Timex
    {
        public Timex(string timex)
        {
        }
        public bool Now { get; set; }

        public int Years { get; set }

        public int Months { get; set }

        public int Weeks { get; set }

        public int Days { get; set }
    }
}
