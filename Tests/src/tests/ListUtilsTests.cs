using io.github.crisstanza.csharputils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace tests
{
    [TestClass]
    public class ListUtilsTests
    {
        private readonly ListUtils listUtils = new ListUtils();

        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { null, 0 };
                yield return new object[] { new List<string> { }, 0 };
                yield return new object[] { new List<string> { "" }, 1 };
            }
        }

        [TestMethod, DynamicData(nameof(TestData))]
        public void Count(List<string> input, int expected)
        {
            int output = this.listUtils.Count(input);
            Assert.AreEqual(expected, output);
        }
    }
}
