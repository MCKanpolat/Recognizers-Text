using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Recognizers.DataTypes.DateTime
{
    public static class TimexDateHelpers
    {
        public static void Tomorrow()
        {
        }

        public static void Yesterday()
        {
        }

        public static void DatePartEquals()
        {
        }

        public static void IsThisWeek()
        {
        }

        public static void IsNextWeek()
        {
        }

        public static void IsLastWeek()
        {
        }

        public static void WeekOfYear()
        {
        }

        public static string FixedFormatNumber(int? n, int size)
        {
            return n.Value.ToString().PadLeft(size, '0');
        }

        public static void DateOfLastDay()
        {
        }

        public static void DateOfNextDay()
        {
        }

        public static void DatesMatchingDay()
        {
        }
    }
}
