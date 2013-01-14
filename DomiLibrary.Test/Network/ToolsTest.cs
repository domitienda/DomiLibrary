using DomiLibrary.Utility.Helper;
using DomiLibrary.Utility.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomiLibrary.Test.Network
{
    [TestClass]
    public class ToolsTest
    {
        [TestMethod]
        public void WhoisInformationTest()
        {
            var result = Tools.GetWhoisInformation("whois.internic.net", "recompralo.com");
            var dns = StringHelper.SearchString(result, "Name Server: ", "\r\n");
            Assert.AreEqual(2, dns.Count);
        }
    }
}
