using DomiLibrary.Utility.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomiLibrary.Test.Helper
{
    [TestClass]
    public class WmiHelperTest
    {
        [TestMethod]
        public void InvokeRemoteCommand()
        {
            var result = WmiHelper.InvokeRemoteCommand("192.168.1.1", "user", "pass", "notepad.exe");
            Assert.AreEqual("0", result);
        }
    }
}
