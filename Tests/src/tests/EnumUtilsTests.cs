using io.github.crisstanza.csharputils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;

namespace tests
{
    [TestClass]
    public class EnumUtilsTests
    {
        private readonly EnumUtils enumUtils = new EnumUtils();
        private enum TestEnum
        {
            None,

            [EnumMember(Value = "some value")]
            Some,

            [EnumMember(Value = null)]
            Null,

            [EnumMember]
            NoValue
        }

        [TestMethod]
        [DataRow("None", null)]
        [DataRow("Some", "some value")]
        [DataRow("Null", null)]
        [DataRow("NoValue", null)]
        [DataRow("NotFound", null)]
        public void GetMemberValue(string inputName, string expected)
        {
            string output = this.enumUtils.GetMemberValue(typeof(TestEnum), inputName);
            Assert.AreEqual(expected, output);
        }
    }
}
