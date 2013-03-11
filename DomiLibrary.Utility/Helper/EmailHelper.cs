using System;
using System.Net;
using System.Net.Mail;

namespace DomiLibrary.Utility.Helper
{
    /// <summary>
    /// Helper encargado de almacenar logica para el envio de emails
    /// </summary>
    public class EmailHelper
    {
        /// <summary>
        /// Metodo que envía un mail pasando los parametros requeridos
        /// Usa credenciales para poder conectarse con el servidor SMTP
        /// </summary>
        /// <param name="usuario">Nombre de usuario</param>
        /// <param name="clave">Clave de usuario</param>
        /// <param name="from">Email desde donde se envia</param>
        /// <param name="to">Email que recibira el email</param>
        /// <param name="servidor">IP del servidor de envio</param>
        /// <param name="puerto">Puerto del servidor de envio</param>
        /// <param name="asunto">Asunto del email</param>
        /// <param name="cuerpo">Cuerpo del email</param>
        public static void SendEmail(string usuario, string clave, string from, string to, 
            string servidor, int puerto, string asunto, string cuerpo)
        {
            var fromAddress = new MailAddress(from);
            var toAddress = new MailAddress(to);
            var subject = asunto;
            var body = cuerpo;

            var smtp = new SmtpClient
            {
                Host = servidor,
                Port = puerto,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(usuario, clave)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                try
                {
                    smtp.Send(message);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
