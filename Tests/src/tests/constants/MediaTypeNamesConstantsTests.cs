using io.github.crisstanza.csharputils;
using io.github.crisstanza.csharputils.constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests.constants
{
    [TestClass]
    public class MediaTypeNamesConstantsTests
    {
        [TestMethod]
        public void Tests()
        {
            Assert.AreEqual(MediaTypeNamesConstants.APPLICATION_JSON, "application/json");
            Assert.AreEqual(MediaTypeNamesConstants.TEXT_CSS, "text/css");
            Assert.AreEqual(MediaTypeNamesConstants.TEXT_HTML, "text/html");
            Assert.AreEqual(MediaTypeNamesConstants.TEXT_JAVASCRIPT, "text/javascript");
            Assert.AreEqual(MediaTypeNamesConstants.IMAGE_ICON, "image/icon");
        }
    }
}
