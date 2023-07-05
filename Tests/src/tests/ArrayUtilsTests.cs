using io.github.crisstanza.csharputils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class ArrayUtilsTests
    {
        private readonly ArrayUtils arrayUtils = new ArrayUtils();

        [TestMethod]
        [DataRow(null, 0)]
        [DataRow(new byte[] { }, 0)]
        [DataRow(new byte[] { 0 }, 1)]
        [DataRow(new byte[] { 1, 2, 3 }, 3)]
        public void Size(byte[] input, int expected)
        {
            int output = this.arrayUtils.Size(input);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        [DataRow(null, 0)]
        [DataRow(new byte[] { }, 0)]
        [DataRow(new byte[] { 0 }, 0)]
        [DataRow(new byte[] { 1, 0, 2 }, 1)]
        [DataRow(new byte[] { 1, 2, 3, 0, 0 }, 3)]
        public void StringSize(byte[] input, int expected)
        {
            int output = this.arrayUtils.StringSize(input);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        [DataRow(0, null, "")]
        [DataRow(0, new string[] { "a", "b" }, "ab")]
        [DataRow(1, new string[] { "a", "b", "c" }, "bc")]
        [DataRow(10, new string[] { "a", "b", "c" }, "")]
        public void Join(int inputStart, string[] inputArray, string expected)
        {
            string output = this.arrayUtils.Join(inputStart, inputArray);
            Assert.AreEqual(expected, output);
        }
    }
}
