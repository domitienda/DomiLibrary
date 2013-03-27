using System.Collections.Generic;
using DomiLibrary.Utility.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomiLibrary.Test.Helper
{
    [TestClass]
    public class StringHelperTest
    {
        [TestMethod]
        public void IsBlankTest1()
        {
            var result = StringHelper.IsBlank("hola");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsBlankTest2()
        {
            var result = StringHelper.IsBlank("");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FormatStringTest1()
        {
            var result = StringHelper.FormatString("hola", 6, "0");
            Assert.AreEqual("00hola", result);
        }

        [TestMethod]
        public void GetIndexesByCharacterTest1()
        {
            var result = StringHelper.GetIndexesByCharacter("hola_me_llamo_ivan", '_');
            var expected = new List<int> {4, 7, 13};
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ReplaceByIndexTest1()
        {
            var result = StringHelper.ReplaceByIndex("HolaMeLlamoivan", "I", 11);
            Assert.AreEqual("HolaMeLlamoIvan", result);
        }

        [TestMethod]
        public void ReplaceByIndexTest2()
        {
            var result = StringHelper.ReplaceByIndex("holaMeLlamoIvan", "H", 0);
            Assert.AreEqual("HolaMeLlamoIvan", result);
        }

        [TestMethod]
        public void ToPascalTest1()
        {
            var result = StringHelper.ToPascalCase("holaMeLlamo_ivan");
            Assert.AreEqual("HolaMeLlamoIvan", result);
        }

        [TestMethod]
        public void ToPascalTest2()
        {
            var result = StringHelper.ToPascalCase("holaMeLlamo ivan");
            Assert.AreEqual("HolaMeLlamoIvan", result);
        }

        [TestMethod]
        public void Remove()
        {
            var arrayCharacters = new char[] {'a', 'v'};
            var result = StringHelper.Remove("Ivan", arrayCharacters);
            Assert.AreEqual("In", result);
        }
    }
}
