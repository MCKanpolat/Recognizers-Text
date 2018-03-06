
using System.Collections.Generic;

namespace Microsoft.Recognizers.DataTypes.DateTime
{
    public class Timex
    {
        public Timex(string timex)
        {
            TimexParsing.ParseString(timex, this);
        }

        public Timex TimexValue
        {
            get
            {
                // TODO: TimexFormat.Format(this)
                return null;
            }
        }

        public HashSet<string> Types
        {
            get
            {
                // TODO: TimexInference.Infer(this)
                return null;
            }
        }

        public override string ToString()
        {
            // TODO: TimexConvert.ConvertTimexToSTring(this)
            return null;
        }

        public string ToNaturalLanguage(System.DateTime referenceDate)
        {
            // TODO: TimexRelativeConvert.ConvertTimexToStringRelative(this, referenceDate)
            return null;
        }

        public bool? Now { get; set; }

        public int? Years { get; set; }

        public int? Months { get; set; }

        public int? Weeks { get; set; }

        public int? Days { get; set; }

        public int? Hours { get; set; }

        public int? Minutes { get; set; }

        public int? Seconds { get; set; }

        public int? Year { get; set; }

        public int? Month { get; set; }

        public int? DayOfMonth { get; set; }

        public int? DayOfWeek { get; set; }

        public string Season { get; set; }

        public int? WeekOfYear { get; set; }

        public bool? Weekend { get; set; }

        public int? WeekOfMonth { get; set; }

        public int? Hour { get; set; }

        public int? Minute { get; set; }

        public int? Second { get; set; }

        public string PartOfDay { get; set; }

        public void AssignProperties(IDictionary<string, string> source)
        {
            foreach (var item in source)
            {
                switch (item.Key)
                {
                    case "year":
                        Year = int.Parse(item.Value);
                        break;
                    case "month":
                        Month = int.Parse(item.Value);
                        break;
                    case "dayOfMonth":
                        DayOfMonth = int.Parse(item.Value);
                        break;
                    case "dayOfWeek":
                        DayOfWeek = int.Parse(item.Value);
                        break;
                    case "season":
                        Season = item.Value;
                        break;
                    case "weekOfYear":
                        WeekOfYear = int.Parse(item.Value);
                        break;
                    case "weekend":
                        Weekend = true;
                        break;
                    case "weekOfMonth":
                        WeekOfMonth = int.Parse(item.Value);
                        break;
                    case "hour":
                        Hour = int.Parse(item.Value);
                        break;
                    case "minute":
                        Minute = int.Parse(item.Value);
                        break;
                    case "second":
                        Second = int.Parse(item.Value);
                        break;
                    case "partOfDay":
                        PartOfDay = item.Value;
                        break;
                    case "dateUnit":
                        AssignDateUnit(source);
                        break;
                    case "timeUnit":
                        AssignTimeUnit(source);
                        break;
                }
            }
            if (Hour != null || Minute != null || Second != null)
            {
                if (Hour == null)
                {
                    Hour = 0;
                }
                if (Minute == null)
                {
                    Minute = 0;
                }
                if (Second == null)
                {
                    Second = 0;
                }
            }
        }

        private void AssignDateUnit(IDictionary<string, string> source)
        {
            switch (source["dateUnit"])
            {
                case "Y":
                    Years = int.Parse(source["amount"]);
                    break;
                case "M":
                    Months = int.Parse(source["amount"]);
                    break;
                case "W":
                    Weeks = int.Parse(source["amount"]);
                    break;
                case "D":
                    Days = int.Parse(source["amount"]);
                    break;
            }
        }

        private void AssignTimeUnit(IDictionary<string, string> source)
        {
            switch (source["timeUnit"])
            {
                case "H":
                    Hours = int.Parse(source["amount"]);
                    break;
                case "M":
                    Minutes = int.Parse(source["amount"]);
                    break;
                case "S":
                    Seconds = int.Parse(source["amount"]);
                    break;
            }
        }
    }
}
