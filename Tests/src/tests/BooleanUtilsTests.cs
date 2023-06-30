using io.github.crisstanza.csharputils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class BooleanUtilsTests
    {
        private readonly BooleanUtils booleanUtils = new BooleanUtils();

        [TestMethod]
        [DataRow(1, true)]
        [DataRow(0, false)]
        [DataRow(2, false)]
        [DataRow(null, false)]
        public void FromInt(int input, bool expected)
        {
            bool output = this.booleanUtils.FromInt(input);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        [DataRow(true, 1)]
        [DataRow(false, 0)]
        [DataRow(null, 0)]
        public void ToInt(bool input, int expected)
        {
            int output = this.booleanUtils.ToInt(input);
            Assert.AreEqual(expected, output);
        }
    }
}
