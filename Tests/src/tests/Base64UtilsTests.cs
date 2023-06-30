using io.github.crisstanza.csharputils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace tests
{
    [TestClass]
    public class Base64UtilsTests
    {
        private readonly Base64Utils base64Utils = new Base64Utils();

        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { null, null };
                yield return new object[] { new byte[] { }, "" };
                yield return new object[] { new byte[] { ((byte)'A') }, "QQ==" };
            }
        }

        [TestMethod, DynamicData(nameof(TestData))]
        public void FromByteArray(byte[] input, string expected)
        {
            string output = this.base64Utils.FromByteArray(input);
            Assert.AreEqual(expected, output);
        }

        [TestMethod, DynamicData(nameof(TestData))]
        public void ToByteArray(byte[] expected, string input)
        {
            byte[] output = this.base64Utils.ToByteArray(input);
            CollectionAssert.AreEqual(expected, output);
        }
    }
}
