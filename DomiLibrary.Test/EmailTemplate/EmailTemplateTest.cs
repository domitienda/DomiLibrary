using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DomiLibrary.Utility.Email;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomiLibrary.Test.EmailTemplate
{
    [TestClass]
    public class EmailTemplateTest
    {
        [TestMethod]
        public void TestContruirCuerpo()
        {
            var configEmail = new ConfigEmail
                                  {
                                      ClaveUsuario = "123456",
                                      IpServidor = "domitienda.com",
                                      NombreUsuario = "ivan.oliver@domitienda.com",
                                      PuertoServidor = 25,
                                      Ssl = false
                                  };
            var tags = new Dictionary<string, string>
                           {{"PEDIDO", "000000000"}, {"EMAIL", "ivan.oliver@domitienda.com"}, {"EMPRESA", "Domitienda"}};
            var emailTemplate = new Utility.Email.EmailTemplate(configEmail);
            var cuerpo = emailTemplate.ContruirCuerpo("http://www.domitienda.com/plantillas/pedidogenerado.html", tags);
            
            Assert.IsNotNull(cuerpo);
        }
    }
}
