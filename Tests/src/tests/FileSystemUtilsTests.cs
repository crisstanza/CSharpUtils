using io.github.crisstanza.csharputils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class FileSystemUtilsTests
    {
        private readonly FileSystemUtils fileSystemUtils = new FileSystemUtils();

        [TestMethod]
        public void CurrentPath()
        {
            string output = this.fileSystemUtils.CurrentPath();
            Assert.IsNotNull(output);
        }
    }
}
