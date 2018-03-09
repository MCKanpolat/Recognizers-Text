using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Recognizers.DataTypes.DateTime
{
    public class TimexSet
    {
        public TimexSet(Timex timex)
        {
            Timex = timex;
        }

        public Timex Timex { get; set; }
    }
}
