using System.IO;
using DomiLibrary.Utility.Dns.Bind;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomiLibrary.Test.Dns.Bind
{
    [TestClass]
    public class ParsearFicheroZonaTest
    {
        [TestMethod]
        public void GetLineaStringNumSerie()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringNumSerie();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetLineaStringTiempoActualizacion()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringTiempoActualizacion();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetLineaStringTiempoReintento()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringTiempoReintento();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetLineaStringTiempoCaducidad()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringTiempoCaducidad();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetLineaStringTiempoVida()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringTiempoVida();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetLineaStringNs()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringNs();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetLineaStringMx()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringMx();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetLineaStringA()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringA();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetLineaStringAaa()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringAaa();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetLineaStringCname()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringCname();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetLineaStringPtr()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringPtr();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetLineaStringSpf()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringSpf();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetLineaStringAEncabezado()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringA("ftp");

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetLineaStringAaaEncabezado()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringAaa("ftp");

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetLineaStringCnameEncabezado()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaStringCname("www");

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetLineasAaa()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineasAaa();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetLineasA()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineasA();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetLineasCname()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineasCname();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetLineasZonaTest1()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\adiosssss.com.txt");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineasZona();
            Assert.AreEqual(7, result.Count);
        }

        [TestMethod]
        public void GetLineasZonaTest2()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.txt");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineasZona();
            Assert.AreEqual(6, result.Count);
        }

        [TestMethod]
        public void GetLineasZonaTest3()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\liststwitter.com.txt");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineasZona();
            Assert.AreEqual(6, result.Count);
        }
    }
}
