using io.github.crisstanza.csharputils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tests
{
    [TestClass]
    public class DiagnosticsUtilsTests
    {
        private readonly DiagnosticsUtils diagnosticsUtils = new DiagnosticsUtils();

        [TestMethod]
        public void Now()
        {
            DiagnosticsUtils.CpuDiagnostics output = this.diagnosticsUtils.GetCpuDiagnostics();
            Assert.IsNotNull(output);
        }
    }
}
