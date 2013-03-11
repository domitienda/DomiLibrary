using System;
using System.Collections;
using System.Collections.Generic;
using DomiLibrary.Test.Helper.EntityTest;
using DomiLibrary.Utility.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomiLibrary.Test.Helper
{
    [TestClass]
    public class CollectionHelperTest
    {
        [TestMethod]
        public void IsEmptyTest1()
        {
            ICollection list = null;
            var result = CollectionHelper.IsEmpty(list);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmptyTest2()
        {
            var list = new ArrayList();
            var result = CollectionHelper.IsEmpty(list);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmptyTest3()
        {
            var array = new int[0];
            var result = CollectionHelper.IsEmpty(array);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmptyTest4()
        {
            IList<Object> list = new List<Object>();
            var result = CollectionHelper.IsEmpty(list);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmptyTest5()
        {
            var list = new ArrayList {string.Empty};
            var result = CollectionHelper.IsEmpty(list);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsEmptyTest6()
        {
            var array = new int[1];
            array[0] = 1;
            var result = CollectionHelper.IsEmpty(array);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsEmptyTest7()
        {
            IList<Object> list = new List<Object>();
            list.Add(1);
            var result = CollectionHelper.IsEmpty(list);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SubtractTest1()
        {
            var a = new List<Extension>
                        {
                            new Extension(1, "1"), 
                            new Extension(2, "2"), 
                            new Extension(3, "3")
                        };
            var b = new List<Extension>
                        {
                            new Extension(1, "1")
                        };

            var result = CollectionHelper.Subtract((IList<Extension>)a, (IList<Extension>)b);
            Assert.AreEqual(2, result.Count);
        }
    }
}
