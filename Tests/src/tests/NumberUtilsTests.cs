using io.github.crisstanza.csharputils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class NumberUtilsTests
    {
        private readonly NumberUtils numberUtils = new NumberUtils();

        [TestMethod]
        [DataRow(0, "0 bytes")]
        [DataRow(1, "1 byte")]
        [DataRow(1024, "1 KB")]
        [DataRow(1024 + 512, "1.5 KB")]
        [DataRow(1024 * 1024, "1 MB")]
        [DataRow((int)(1024 * 1024 * 1.5), "1.5 MB")]
        [DataRow(1024 * 1024 * 1024, "1 GB")]
        [DataRow((int)(1024 * 1024 * 1024 * 1.3), "1.29 GB")]
        public void SizeFromBytes(int input, string expected)
        {
            string output = this.numberUtils.SizeFromBytes(input);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        [DataRow(0, 0, "0x0")]
        [DataRow(0, 1, "0x0")]
        [DataRow(0, 2, "0x00")]
        [DataRow(100, 4, "0x0064")]
        public void ToHexa(int inputNumber, int inputSize, string expected)
        {
            string output = this.numberUtils.ToHexa(inputNumber, inputSize);
            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        [DataRow(-1 / 6.0, "-0.16")]
        [DataRow(-1, "-1")]
        [DataRow(0, "0")]
        [DataRow(1, "1")]
        [DataRow(1.5, "1.5")]
        [DataRow(1.999, "1.99")]
        [DataRow(1000 / 3.0, "333.33")]
        public void Truncate2(double input, string expected)
        {
            string output = this.numberUtils.Truncate2(input);
            Assert.AreEqual(expected, output);
        }
    }
}
