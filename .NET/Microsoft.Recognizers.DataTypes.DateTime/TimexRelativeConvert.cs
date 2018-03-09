using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Recognizers.DataTypes.DateTime
{
    public static class TimexRelativeConvert
    {
        public static string ConvertTimexToStringRelative(Timex timex, System.DateTime referenceDate)
        {
            return TimexRelativeConvertEn.ConvertTimexToStringRelative(timex, referenceDate);
        }
    }
}
