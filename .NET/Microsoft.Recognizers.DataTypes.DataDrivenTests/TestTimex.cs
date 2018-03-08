﻿
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Recognizers.DataTypes.DateTime.Tests
{
    [TestClass]
    public class TestTimex
    {
        [TestMethod]
        public void Timex_FromDate()
        {
            Assert.AreEqual("2017-12-05", Timex.FromDate(new System.DateTime(2017, 12, 5)).TimexValue);
        }

        [TestMethod]
        public void Timex_FromDateTime()
        {
            Assert.AreEqual("2017-12-05T23:57:35", Timex.FromDateTime(new System.DateTime(2017, 12, 5, 23, 57, 35)).TimexValue);
        }

        [TestMethod]
        public void Timex_FromTime()
        {
            Assert.AreEqual("T23:59:30", Timex.FromTime(new Time(23, 59, 30)).TimexValue);
        }

        private static void Roundtrip(string timex)
        {
            Assert.AreEqual(timex, (new Timex(timex)).TimexValue);
        }

        [TestMethod]
        public void Timex_Roundtrip_Date()
        {
            Roundtrip("2017-09-27");
            Roundtrip("XXXX-WXX-3");
            Roundtrip("XXXX-12-05");
        }

        [TestMethod]
        public void Timex_Roundtrip_Time()
        {
            Roundtrip("T17:30:45");
            Roundtrip("T05:06:07");
            Roundtrip("T17:30");
            Roundtrip("T23");
        }

        [TestMethod]
        public void Timex_Roundtrip_Duration()
        {
            Roundtrip("P50Y");
            Roundtrip("P6M");
            Roundtrip("P3W");
            Roundtrip("P5D");
            Roundtrip("PT16H");
            Roundtrip("PT32M");
            Roundtrip("PT20S");
        }

        [TestMethod]
        public void Timex_Roundtrip_Now()
        {
            Roundtrip("PRESENT_REF");
        }

        [TestMethod]
        public void Timex_Roundtrip_DateTime()
        {
            Roundtrip("XXXX-WXX-3T04");
            Roundtrip("2017-09-27T11:41:30");
        }

        [TestMethod]
        public void Timex_Roundtrip_DateRange()
        {
            Roundtrip("2017");
            Roundtrip("SU");
            Roundtrip("2017-WI");
            Roundtrip("2017-09");
            Roundtrip("2017-W37");
            Roundtrip("2017-W37-WE");
            Roundtrip("XXXX-05");
        }

        [TestMethod]
        public void Timex_Roundtrip_DateRange_Start_End_Duration()
        {
            Roundtrip("(XXXX-WXX-3,XXXX-WXX-6,P3D)");
            Roundtrip("(XXXX-01-01,XXXX-08-05,P216D)");
            Roundtrip("(2017-01-01,2017-08-05,P216D)");
            Roundtrip("(2016-01-01,2016-08-05,P217D)");
        }

        [TestMethod]
        public void Timex_Roundtrip_TimeRange()
        {
            Roundtrip("TEV");
        }

        [TestMethod]
        public void Timex_Roundtrip_TimeRange_Start_End_Duration()
        {
            Roundtrip("(T16,T19,PT3H)");
        }

        [TestMethod]
        public void Timex_Roundtrip_DateTimeRange()
        {
            Roundtrip("2017-09-27TEV");
        }

        [TestMethod]
        public void Timex_Roundtrip_DateTimeRange_Start_End_Duration()
        {
            Roundtrip("(2017-09-08T21:19:29,2017-09-08T21:24:29,PT5M)");
            Roundtrip("(XXXX-WXX-3T16,XXXX-WXX-6T15,PT71H)");
        }

        [TestMethod]
        public void Timex_ToString()
        {
            Assert.AreEqual("5th May", (new Timex("XXXX-05-05")).ToString());
        }

        [TestMethod]
        public void Timex_ToNaturalLanguage()
        {
            var today = new System.DateTime(2017, 9, 16);
            Assert.AreEqual("tomorrow", (new Timex("2017-10-17")).ToNaturalLanguage(today));
        }
    }
}
