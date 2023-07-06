using io.github.crisstanza.csharputils.constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests.constants
{
    [TestClass]
    public class StopwatchConstantsTests
    {
        [TestMethod]
        public void Tests()
        {
            Assert.AreEqual(StopwatchConstants.DURATION, "{0}|{1}:{2}:{3}|{4}");
        }
    }
}
