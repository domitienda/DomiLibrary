using DomiLibrary.Utility.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomiLibrary.Test.Helper
{
    [TestClass]
    public class MemberHelperTest
    {
        [TestMethod]
        public void GetNameParameterTest1()
        {
            var parametro = string.Empty;
            var result = MemberHelper.GetNameParameter(() => parametro);
            Assert.AreEqual("parametro", result);
        }
    }
}
