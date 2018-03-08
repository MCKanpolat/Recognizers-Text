using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Recognizers.DataTypes.DateTime
{
    public class TimexRange
    {
        public Timex Start { get; set; }
        public Timex End { get; set; }
        public Timex Duration { get; set; }
    }
}
