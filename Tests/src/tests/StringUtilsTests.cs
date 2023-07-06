using io.github.crisstanza.csharputils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class StringUtilsTests
    {
        private readonly StringUtils stringUtils = new StringUtils();

        [TestMethod]
        [DataRow(null, null, null)]
        [DataRow(null, "", "")]
        [DataRow("\t", "Z", "Z")]
        [DataRow("", "ok", "ok")]
        [DataRow("   ", "ok", "ok")]
        [DataRow("x", "y", "x")]
        public void Default(string inputValue, string inputFallback, string expected)
        {
            string output = this.stringUtils.Default(inputValue, inputFallback);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        [DataRow(null, true)]
        [DataRow("", true)]
        [DataRow(" ", true)]
        [DataRow("value", false)]
        public void IsBlank(string input, bool expected)
        {
            bool output = this.stringUtils.IsBlank(input);
            Assert.AreEqual(expected, output);
        }
    }
}
