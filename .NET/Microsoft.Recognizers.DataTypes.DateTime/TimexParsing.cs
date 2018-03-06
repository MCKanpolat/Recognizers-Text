using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Recognizers.DataTypes.DateTime
{
    public static class TimexParsing
    {
        public static void ParseString(string timex, Timex obj)
        {
            // a reference to the present
            if (timex == "PRESENT_REF")
            {
                obj.Now = true;
            }
            // duration
            else if (timex.StartsWith("P"))
            {
                ExtractDuration(timex, obj);
            }
            // range indicated with start and end dates and a duration
            else if (timex.StartsWith("(") && timex.EndsWith(")"))
            {
                ExtractStartEndRange(timex, obj);
            }
            // date and time and their respective ranges
            else
            {
                ExtractDateTime(timex, obj);
            }
        }

        private static void ExtractDuration(string s, Timex obj)
        {
            var extracted = new Dictionary<string, string>();
            TimexRegex.Extract("period", s, extracted);
            if (extracted.ContainsKey("dateUnit"))
            {
                ExtractDateUnit(extracted, obj);
            }
            else if (extracted.ContainsKey("timeUnit"))
            {
                ExtractTimeUnit(extracted, obj);
            }
        }

        private static void ExtractDateUnit(IDictionary<string, string> extracted, Timex obj)
        {
            switch (extracted["dateUnit"])
            {
                case "Y":
                    obj.Years = int.Parse(extracted["amount"]);
                    break;
                case "M":
                    obj.Months = int.Parse(extracted["amount"]);
                    break;
                case "W":
                    obj.Weeks = int.Parse(extracted["amount"]);
                    break;
                case "D":
                    obj.Days = int.Parse(extracted["amount"]);
                    break;
            }
        }

        private static void ExtractTimeUnit(IDictionary<string, string> extracted, Timex obj)
        {
        }

        private static void ExtractStartEndRange(string timex, Timex obj)
        {
        }

        private static void ExtractDateTime(string timex, Timex obj)
        {
        }
    }
}
