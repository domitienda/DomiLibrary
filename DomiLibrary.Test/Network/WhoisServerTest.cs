using DomiLibrary.Utility.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomiLibrary.Test.Network
{
    [TestClass]
    public class WhoisServerTest
    {
        [TestMethod]
        public void GetDomainNameTest()
        {
            var result = WhoisServerHelper.GetDomainName("whois.nic.es", "recompralo.es");
            Assert.AreEqual("RECOMPRALO.COM", result.ToUpper());
        }

        [TestMethod]
        public void GetWhoisServerTest()
        {
            var result = WhoisServerHelper.GetWhoisServer("whois.internic.net", "recompralo.com");
            Assert.AreEqual("whois2.virtualname.es", result);
        }

        [TestMethod]
        public void GetReferralUrlTest()
        {
            var result = WhoisServerHelper.GetReferralUrl("whois.internic.net", "recompralo.com");
            Assert.AreEqual("http://www.virtualname.es", result);
        }

        [TestMethod]
        public void GetNameServerTest()
        {
            var result = WhoisServerHelper.GetNameServer("whois.verisign-grs.com", "recompralo.com");
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetStatusTest()
        {
            var result = WhoisServerHelper.GetStatus("whois.internic.net", "recompralo.com");
            Assert.AreEqual("clienttransferprohibited", result);
        }

        [TestMethod]
        public void GetUpdateDateTest()
        {
            var result = WhoisServerHelper.GetUpdateDate("whois.internic.net", "recompralo.com");
            Assert.AreEqual("17-sep-2012", result);
        }

        [TestMethod]
        public void GetCreationDateTest()
        {
            var result = WhoisServerHelper.GetCreationDate("whois.internic.net", "recompralo.com");
            Assert.AreEqual("30-nov-2011", result);
        }

        [TestMethod]
        public void GetExpirationDateTest()
        {
            var result = WhoisServerHelper.GetExpirationDate("whois.internic.net", "recompralo.com");
            Assert.AreEqual("30-nov-2013", result);
        }

        [TestMethod]
        public void GetInformationServerComplete()
        {
            var url = "domitienda.com";
            var whoisServer = WhoisServerProxy.Proxy("com");
            var result = WhoisServerHelper.GetWhoisInformationComplete(whoisServer, url);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(string.Empty, result);
        }
    }
}
