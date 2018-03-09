﻿using System;

namespace Microsoft.Recognizers.DataTypes.DateTime
{
    internal static class TimexConvertEn
    {
        public static string ConvertTimexToString(Timex timex)
        {
            var types = timex.Types.Count != 0 ? timex.Types : TimexInference.Infer(timex);

            if (types.Contains(Constants.TimexTypes.Present))
            {
                return "now";
            }
            if (types.Contains(Constants.TimexTypes.DateTimeRange))
            {
                return ConvertDateTimeRange(timex);
            }
            if (types.Contains(Constants.TimexTypes.DateRange))
            {
                return ConvertDateRange(timex);
            }

            if (types.Contains(Constants.TimexTypes.Duration))
            {
                return ConvertDuration(timex);
            }

            if (types.Contains(Constants.TimexTypes.TimeRange))
            {
                return ConvertTimeRange(timex);
            }

            // TODO: where appropriate delegate most the formatting delegate to Date.toLocaleString(options)

            if (types.Contains(Constants.TimexTypes.DateTime)) 
            {
                return ConvertDateTime(timex);
            }

            if (types.Contains(Constants.TimexTypes.Date))
            {
                return ConvertDate(timex);
            }

            if (types.Contains(Constants.TimexTypes.Time))
            {
                return ConvertTime(timex);
            }
            return string.Empty;
        }

        public static string ConvertTimexSetToString(TimexSet timexSet)
        {
            var timex = timexSet.Timex;
            if (timex.Types.Contains(Constants.TimexTypes.Duration))
            {
                return $"every {ConvertTimexDurationToString(timex, false)}";
            }
            else {
                return $"every {ConvertTimexToString(timex)}";
            }
        }

        public static string ConvertTime(Timex timex)
        {
            if (timex.Hour == 0 && timex.Minute == 0 && timex.Second == 0)
            {
                return "midnight";
            }
            if (timex.Hour == 12 && timex.Minute == 0 && timex.Second == 0)
            {
                return "midday";
            }

            var hour = (timex.Hour == 0) ? "12" : (timex.Hour > 12) ? (timex.Hour - 12).ToString() : timex.Hour.ToString();
            var minute = (timex.Minute == 0 && timex.Second == 0) ? string.Empty : ":" + timex.Minute.ToString().PadLeft(2, '0');
            var second = (timex.Second == 0) ? string.Empty : ":" + timex.Second.ToString().PadLeft(2, '0');
            var period = timex.Hour < 12 ? "AM" : "PM";

            return $"{hour}{minute}{second}{period}";
        }

        public static string ConvertDate(Timex timex)
        {
            if (timex.DayOfWeek != null)
            {
                return TimexConstantsEn.Days[timex.DayOfWeek.Value - 1];
            }

            var month = TimexConstantsEn.Months[timex.Month.Value - 1];
            var date = timex.DayOfMonth.ToString();
            var abbreviation = TimexConstantsEn.DateAbbreviation[int.Parse(date[date.Length - 1].ToString())];

            if (timex.Year != null)
            {
                return $"{date}{abbreviation} {month} {timex.Year}".Trim();
            }

            return $"{date}{abbreviation} {month}";
        }

        private static string ConvertDurationPropertyToString(decimal value, string property, bool includeSingleCount)
        {
            if (value == 1)
            {
                return includeSingleCount ? "1 " + property : property;
            }
            else
            {
                return $"{value} {property}s";
            }
        }

        private static string ConvertTimexDurationToString(Timex timex, bool includeSingleCount)
        {
            if (timex.Years != null)
            {
                return ConvertDurationPropertyToString(timex.Years.Value, "year", includeSingleCount);
            }
            if (timex.Months != null)
            {
                return ConvertDurationPropertyToString(timex.Years.Value, "month", includeSingleCount);
            }
            if (timex.Weeks != null)
            {
                return ConvertDurationPropertyToString(timex.Years.Value, "week", includeSingleCount);
            }
            if (timex.Days != null)
            {
                return ConvertDurationPropertyToString(timex.Years.Value, "day", includeSingleCount);
            }
            if (timex.Hours != null)
            {
                return ConvertDurationPropertyToString(timex.Years.Value, "hour", includeSingleCount);
            }
            if (timex.Minutes != null)
            {
                return ConvertDurationPropertyToString(timex.Years.Value, "minute", includeSingleCount);
            }
            if (timex.Seconds != null)
            {
                return ConvertDurationPropertyToString(timex.Years.Value, "second", includeSingleCount);
            }
            return string.Empty;
        }

        private static string ConvertDuration(Timex timex)
        {
            return ConvertTimexDurationToString(timex, true);
        }

        private static string ConvertDateRange(Timex timex)
        {
            var season = (timex.Season != null) ? TimexConstantsEn.Seasons[timex.Season] : string.Empty;

            var year = (timex.Year != null) ? timex.Year.ToString() : string.Empty;

            if (timex.WeekOfYear != null)
            {
                if (timex.Weekend != null)
                {
                    throw new NotImplementedException();
                }
            }

            if (timex.Month != null)
            {
                var month = $"{TimexConstantsEn.Months[timex.Month.Value - 1]}";
                if (timex.WeekOfMonth != null)
                {
                    return $"{TimexConstantsEn.Weeks[timex.WeekOfMonth.Value - 1]} week of {month}";
                }
                else
                {
                    return $"{month} {year}".Trim();
                }
            }
            return $"{season} {year}".Trim();
        }

        private static string ConvertTimeRange(Timex timex)
        {
            return TimexConstantsEn.DayParts[timex.PartOfDay];
        }

        private static string ConvertDateTime(Timex timex)
        {
            return $"{ConvertTime(timex)} {ConvertDate(timex)}";
        }

        private static string ConvertDateTimeRange(Timex timex)
        {
            if (timex.Types.Contains(Constants.TimexTypes.TimeRange))
            {
                return $"{ConvertDate(timex)} {ConvertTimeRange(timex)}";
            }

            // date + time + duration
            // - OR - 
            // date + duration

            return string.Empty;
        }
    }
}
