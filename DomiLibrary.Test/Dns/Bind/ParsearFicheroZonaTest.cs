using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DomiLibrary.Utility.Dns.Bind;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomiLibrary.Test.Dns.Bind
{
    [TestClass]
    public class ParsearFicheroZonaTest
    {
        [TestMethod]
        public void GetLineaNumSerie()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaNumSerie();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetLineaTiempoActualizacion()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaTiempoActualizacion();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetLineaTiempoReintento()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaTiempoReintento();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetLineaTiempoCaducidad()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaTiempoCaducidad();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetLineaTiempoVida()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaTiempoVida();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetLineaNs()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaNs();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetLineaMx()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaMx();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetLineaA()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaA();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetLineaAaa()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaAaa();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetLineaCname()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaCname();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetLineaPtr()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaPtr();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetLineaSpf()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaSpf();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetLineaAEncabezado()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaA("ftp");

            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetLineaAaaEncabezado()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaAaa("ftp");

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetLineaCnameEncabezado()
        {
            var streamReader = new StreamReader(@"C:\Users\Ivan\Desktop\ivanoliver.com.db.dns");
            var parsearFicheroZona = new ParsearFicheroZona(streamReader);
            var result = parsearFicheroZona.GetLineaCname("www");

            Assert.AreEqual(1, result.Count);
        }
    }
}
