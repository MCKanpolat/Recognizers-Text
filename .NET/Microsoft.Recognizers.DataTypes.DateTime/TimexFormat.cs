using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Recognizers.DataTypes.DateTime
{
    public static class TimexFormat
    {
        public static string Format(Timex timex)
        {
            var types = timex.Types.Count != 0 ? timex.Types : TimexInference.Infer(timex);

            if (types.Contains("present")) {
                return "PRESENT_REF";
            }
            if ((types.Contains("datetimerange") || types.Contains("daterange") || types.Contains("timerange")) && types.Contains("duration"))
            {
                var range = TimexHelpers.ExpandDateTimeRange(timex);
                return "(${format(range.start)},${format(range.end)},${format(range.duration)})";
            }
            if (types.Contains("datetimerange"))
            {
                return "${formatDate(timex)}${formatTimeRange(timex)}";
            }
            if (types.Contains("daterange"))
            {
                return "${formatDateRange(timex)}";
            }
            if (types.Contains("timerange"))
            {
                return "${formatTimeRange(timex)}";
            }
            if (types.Contains("datetime"))
            {
                return "${formatDate(timex)}${formatTime(timex)}";
            }
            if (types.Contains("duration"))
            {
                return "${formatDuration(timex)}";
            }
            if (types.Contains("date"))
            {
                return "${formatDate(timex)}";
            }
            if (types.Contains("time"))
            {
                return "${formatTime(timex)}";
            }
            return string.Empty;
        }
    }
}
