using System;
using System.Collections.Generic;
using DomiLibrary.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomiLibrary.Test.Helper
{
    [TestClass]
    public class ValidationHelperTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotNullTest1()
        {
            ValidationHelper.NotNull(null, string.Empty);
        }

        [TestMethod]
        public void NotNullTest2()
        {
            ValidationHelper.NotNull("prueba", string.Empty);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotBlankTest1()
        {
            var input = string.Empty;
            ValidationHelper.NotBlank(input, string.Empty);
        }

        [TestMethod]
        public void NotBlankTest2()
        {
            var input = "prueba";
            ValidationHelper.NotBlank(input, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotEmptyTest1()
        {
            ICollection<int> input = new List<int>();
            ValidationHelper.NotEmpty(input, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotEmptyTest2()
        {
            var input = new int[0];
            ValidationHelper.NotEmpty(input, string.Empty);
        }

        [TestMethod]
        public void NotEmptyTest3()
        {
            ICollection<int> input = new List<int>();
            input.Add(1);
            ValidationHelper.NotEmpty(input, string.Empty);
        }

        [TestMethod]
        public void NotEmptyTest4()
        {
            var input = new int[1];
            input[0] = 1;
            ValidationHelper.NotEmpty(input, string.Empty);
        }
    }
}
