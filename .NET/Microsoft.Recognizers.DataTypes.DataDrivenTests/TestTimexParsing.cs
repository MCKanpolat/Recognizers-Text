using Microsoft.Recognizers.DataTypes.DateTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Recognizers.DataTypes.DataDrivenTests
{
    [TestClass]
    public class TestTimexParsing
    {
        [TestMethod]
        public void CompleteDate()
        {
            var timex = new Timex("2017-05-29");
            // TODO: timex.should.have.property('types').that.is.a('Set').that.has.keys('definite', 'date');
            Assert.AreEqual(2017, timex.Year);
            Assert.AreEqual(5, timex.Month);
            Assert.AreEqual(29, timex.DayOfMonth);
            Assert.IsNull(timex.DayOfWeek);
            Assert.IsNull(timex.WeekOfYear);
            Assert.IsNull(timex.WeekOfMonth);
            Assert.IsNull(timex.Season);
            Assert.IsNull(timex.Hour);
            Assert.IsNull(timex.Minute);
            Assert.IsNull(timex.Second);
            Assert.IsNull(timex.Weekend);
            Assert.IsNull(timex.PartOfDay);
            Assert.IsNull(timex.Years);
            Assert.IsNull(timex.Months);
            Assert.IsNull(timex.Weeks);
            Assert.IsNull(timex.Days);
            Assert.IsNull(timex.Hours);
            Assert.IsNull(timex.Minutes);
            Assert.IsNull(timex.Seconds);
            Assert.IsNull(timex.Now);
        }
    }
}
