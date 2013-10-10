using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymillWrapper.Net;

namespace UnitTest.Net
{
    [TestClass]
    public class TestFilter
    {
        /// <summary>
        /// Gets or sets the test context which provides information and functionality for 
        /// the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void EncodeFilter()
        {
            var filter = new Filter();
            filter.Add("count", 1);
            filter.Add("offset", 2);
            filter.Add("interval", "month");
            filter.Add("amount", 495);
            filter.Add("created_at", 1352930695);
            filter.Add("trial_period_days", 5);

            const string expected = "count=1&offset=2&interval=month&amount=495&created_at=1352930695&trial_period_days=5";
            var reply = filter.ToString();

            Assert.AreEqual(expected, reply);
        }

    }
}
