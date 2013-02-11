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
        /// <param name="usuario"></param>
        /// <param name="clave"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="servidor"></param>
        /// <param name="puerto"></param>
        /// <param name="asunto"></param>
        /// <param name="cuerpo"></param>
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
                smtp.Send(message);
            }
        }
    }
}
