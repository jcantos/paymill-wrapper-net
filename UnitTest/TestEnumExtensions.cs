using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymillWrapper;
using PaymillWrapper.Models;

namespace UnitTest
{
    [TestClass]
    public class TestEnumExtensions
    {
        [TestMethod]
        public void TestCamelCasedEnum()
        {
            var result = CardType.ChinaUnionPay.ToSnakeCase();
            Assert.AreEqual("china_union_pay", result);
        }

        [TestMethod]
        public void TestAllUpperCaseEnum()
        {
            var result = CardType.JCB.ToSnakeCase();
            Assert.AreEqual("jcb", result);
        }
    }
}
