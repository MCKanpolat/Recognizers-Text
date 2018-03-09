namespace Microsoft.Recognizers.DataTypes.DateTime
{
    internal class TimexRelativeConvertEn
    {
        public static string ConvertTimexToStringRelative(Timex timex, System.DateTime date)
        {
            var types = timex.Types.Count != 0 ? timex.Types : TimexInference.Infer(timex);

            if (types.Contains(Constants.TimexTypes.DateTimeRange))
            {
                return ConvertDateTimeRange(timex, date);
            }
            if (types.Contains(Constants.TimexTypes.DateRange))
            {
                return ConvertDateRange(timex, date);
            }
            if (types.Contains(Constants.TimexTypes.DateTime))
            {
                return ConvertDateTime(timex, date);
            }
            if (types.Contains(Constants.TimexTypes.Date))
            {
                return ConvertDate(timex, date);
            }

            return TimexConvert.ConvertTimexToString(timex);
        }

        private static string GetDateDay(int day)
        {
            var index = (day == 0) ? 6 : day - 1;
            return TimexConstantsEn.Days[index];
        }

        private static string ConvertDate(Timex timex, System.DateTime date)
        {
            if (timex.Year != null && timex.Month != null && timex.DayOfMonth != null)
            {
                var timexDate = new System.DateTime(timex.Year.Value, timex.Month.Value - 1, timex.DayOfMonth.Value);

                if (TimexDateHelpers.datePartEquals(timexDate, date)) {
                    return 'today';
                }
                const tomorrow = timexDateHelpers.tomorrow(date);
                if (TimexDateHelpers.datePartEquals(timexDate, tomorrow)) {
                    return 'tomorrow';
                }
                const yesterday = timexDateHelpers.yesterday(date);
                if (TimexDateHelpers.datePartEquals(timexDate, yesterday)) {
                    return 'yesterday';
                }
                if (TimexDateHelpers.isThisWeek(timexDate, date)) {
                    return `this ${getDateDay(timexDate.getDay())}`;
                }
                if (TimexDateHelpers.isNextWeek(timexDate, date)) {
                    return `next ${getDateDay(timexDate.getDay())}`;
                }
                if (TimexDateHelpers.isLastWeek(timexDate, date)) {
                    return `last ${getDateDay(timexDate.getDay())}`;
                }
            }
            return TimexConvertEn.ConvertDate(timex);
        }

        private static string ConvertDateTime(Timex timex, System.DateTime date)
        {
            return $"{ConvertDate(timex, date)} {TimexConvertEn.ConvertTime(timex)}";
        }

        private static string ConvertDateRange(Timex timex, System.DateTime date)
        {
            if ('year' in timex) {
                const year = date.getFullYear();
                if (timex.year === year) {
                    if ('weekOfYear' in timex) {
                        const thisWeek = timexDateHelpers.weekOfYear(date);
                        if (thisWeek === timex.weekOfYear) {
                            return timex.weekend? 'this weekend' : 'this week';
                        }
                        if (thisWeek === timex.weekOfYear + 1) {
                            return timex.weekend? 'last weekend' : 'last week';
                        }
                        if (thisWeek === timex.weekOfYear - 1) {
                            return timex.weekend? 'next weekend' : 'next week';
                        }
                    }
                    if ('month' in timex) {
                        const isoMonth = date.getMonth() + 1;
                        if (timex.month === isoMonth) {
                            return 'this month';
                        }
                        if (timex.month === isoMonth + 1) {
                            return 'next month';
                        }
                        if (timex.month === isoMonth - 1) {
                            return 'last month';
                        }
                    }
                    return ('season' in timex) ? `this ${timexConstants.seasons[timex.season]}` : 'this year';
                }
                if (timex.year === year + 1) {
                    return ('season' in timex) ? `next ${timexConstants.seasons[timex.season]}` : 'next year';
                }
                if (timex.year === year - 1) {
                    return ('season' in timex) ? `last ${timexConstants.seasons[timex.season]}` : 'last year';
                }
            }
            return '';
        }

        private static string ConvertDateTimeRange(Timex timex, System.DateTime date)
        {
            if ('year' in timex && 'month' in timex && 'dayOfMonth' in timex) {
                const timexDate = new Date(timex.year, timex.month - 1, timex.dayOfMonth);

                if ('partOfDay' in timex) {
                    if (timexDateHelpers.datePartEquals(timexDate, date)) {
                        if (timex.partOfDay === 'NI') {
                            return 'tonight';
                        }
                        else {
                            return `this ${timexConstants.dayParts[timex.partOfDay]}`;
                        }
                    }
                    const tomorrow = timexDateHelpers.tomorrow(date);
                    if (timexDateHelpers.datePartEquals(timexDate, tomorrow)) {
                        return `tomorrow ${timexConstants.dayParts[timex.partOfDay]}`;
                    }
                    const yesterday = timexDateHelpers.yesterday(date);
                    if (timexDateHelpers.datePartEquals(timexDate, yesterday)) {
                        return `yesterday ${timexConstants.dayParts[timex.partOfDay]}`;
                    }

                    if (timexDateHelpers.isNextWeek(timexDate, date)) {
                        return `next ${getDateDay(timexDate.getDay())} ${timexConstants.dayParts[timex.partOfDay]}`;
                    }

                    if (timexDateHelpers.isLastWeek(timexDate, date)) {
                        return `last ${getDateDay(timexDate.getDay())} ${timexConstants.dayParts[timex.partOfDay]}`;
                    }
                }
            }
            return '';
        }
    }
}
