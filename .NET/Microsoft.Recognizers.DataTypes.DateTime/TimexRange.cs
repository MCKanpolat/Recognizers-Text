using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Recognizers.DataTypes.DateTime
{
    public class TimexRange
    {
        public RangeLimit Start { get; set; }
        public RangeLimit End { get; set; }
        public RangeDuration Duration { get; set; }

        public class RangeLimit
        {
            public int? Year { get; set; }

            public int? Month { get; set; }

            public int? DayOfMonth { get; set; }

            public int? Hour { get; set; }

            public int? Minute { get; set; }

            public int? Second { get; set; }
        }

        public class RangeDuration
        {
            public decimal? Years { get; set; }

            public decimal? Months { get; set; }

            public decimal? Weeks { get; set; }

            public decimal? Days { get; set; }

            public decimal? Hours { get; set; }

            public decimal? Minutes { get; set; }

            public decimal? Seconds { get; set; }
        }
    }
}
