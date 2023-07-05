using io.github.crisstanza.csharputils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class DateTimeUtilsTests
    {
        private readonly DateTimeUtils dateTimeUtils = new DateTimeUtils();

        [TestMethod]
        public void Now()
        {
            string output = this.dateTimeUtils.Now();
            Assert.IsNotNull(output);
        }
    }
}
