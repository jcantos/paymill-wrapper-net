using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymillSharp.Models;
using PaymillSharp.Query;

namespace UnitTest.Query
{
    [TestClass]
    public class TestQuery
    {
        /// <summary>
        /// Gets or sets the test context which provides information and functionality for 
        /// the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void EncodeFilter()
        {
            var filter = new Query<Payment>(null);
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

        [TestMethod]
        public void SubsequentCallsOverwritesValue()
        {
            var filter = new Query<Payment>(null);
            filter.Add("count", 1);
            Assert.AreEqual("count=1", filter.ToString());
            filter.Add("count", 2);
            Assert.AreEqual("count=2", filter.ToString());
            filter.Take(3);
            Assert.AreEqual("count=3", filter.ToString());
        }

    }
}
