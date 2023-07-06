using io.github.crisstanza.csharputils.constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests.constants
{
    [TestClass]
    public class DateFormatConstantsTests
    {
        [TestMethod]
        public void Tests()
        {
            Assert.AreEqual(DateFormatConstants.DDMMYYYY_HHMMSSMICROS, "dd/MM/yyyy HH:mm:ss.ffffff");
        }
    }
}
