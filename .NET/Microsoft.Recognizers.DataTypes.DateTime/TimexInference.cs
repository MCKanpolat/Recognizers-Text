using System.Collections.Generic;

namespace Microsoft.Recognizers.DataTypes.DateTime
{
    public class TimexInference
    {
        public static HashSet<string> Infer(Timex obj)
        {
            var types = new HashSet<string>();

            if (IsPresent(obj))
            {
                types.Add("present");
            }
            if (IsDefinite(obj))
            {
                types.Add("definite");
            }
            if (IsDate(obj))
            {
                types.Add("date");
            }
            if (IsDateRange(obj))
            {
                types.Add("daterange");
            }
            if (IsDuration(obj))
            {
                types.Add("duration");
            }
            if (IsTime(obj))
            {
                types.Add("time");
            }
            if (IsTimeRange(obj))
            {
                types.Add("timerange");
            }
            if (types.Contains("present"))
            {
                types.Add("date");
                types.Add("time");
            }
            if (types.Contains("time") && types.Contains("duration"))
            {
                types.Add("timerange");
            }
            if (types.Contains("date") && types.Contains("time"))
            {
                types.Add("datetime");
            }
            if (types.Contains("date") && types.Contains("duration"))
            {
                types.Add("daterange");
            }
            if (types.Contains("datetime") && types.Contains("duration"))
            {
                types.Add("datetimerange");
            }
            if (types.Contains("date") && types.Contains("timerange"))
            {
                types.Add("datetimerange");
            }
            return types;
        }

        private static bool IsPresent(Timex obj) 
        {
            return obj.Now == true;
        }

        private static bool IsDuration(Timex obj)
        {
            return obj.Years != null
                || obj.Months != null
                || obj.Weeks != null
                || obj.Days != null
                || obj.Hours != null
                || obj.Minutes != null
                || obj.Seconds != null;
        }

        private static bool IsTime(Timex obj)
        {
            return obj.Hour != null && obj.Minute != null && obj.Second != null;
        }

        private static bool IsDate(Timex obj)
        {
            return (obj.Month != null && obj.DayOfMonth != null) || obj.DayOfWeek != null;
        }

        private static bool IsTimeRange(Timex obj)
        {
            return obj.PartOfDay != null;
        }

        private static bool IsDateRange(Timex obj)
        {
            return (obj.Year != null && obj.DayOfMonth == null)
                || (obj.Year != null && obj.Month != null && obj.DayOfMonth == null)
                || (obj.Month != null && obj.DayOfMonth == null)
                || obj.Season != null
                || obj.WeekOfYear != null
                || obj.WeekOfMonth != null;
        }

        private static bool IsDefinite(Timex obj)
        {
            return obj.Year != null && obj.Month != null && obj.DayOfMonth != null;
        }
    }
}
