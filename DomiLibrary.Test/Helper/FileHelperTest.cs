using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DomiLibrary.Utility.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomiLibrary.Test.Helper
{
    [TestClass]
    public class FileHelperTest
    {
        [TestMethod]
        public void GetSizeFolderTest1()
        {
            var tamanyo = FileHelper.GetSizeFolder(@"\\91.213.46.2\BackupsBasesDeDatos\ivanoliver\wp_ivanoliver");
        }
    }
}
