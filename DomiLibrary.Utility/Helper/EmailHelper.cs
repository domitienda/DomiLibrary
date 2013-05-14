using System;
using System.Net;
using System.Net.Mail;
using DomiLibrary.Utility.Email;

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
        /// <param name="ssl">Define si se usa SSL</param>
        public static void SendEmail(string usuario, string clave, string from, string to, 
            string servidor, int puerto, string asunto, string cuerpo, bool ssl)
        {
            var fromAddress = new MailAddress(from);
            var toAddress = new MailAddress(to);
            var subject = asunto;
            var body = cuerpo;

            var smtp = new SmtpClient
            {
                Host = servidor,
                Port = puerto,
                EnableSsl = ssl,
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

        /// <summary>
        /// Metodo que envía un mail pasando los parametros requeridos
        /// Usa credenciales para poder conectarse con el servidor SMTP
        /// </summary>
        /// <param name="configEmail">Clase que define la configuración del servidor de correo</param>
        /// <param name="from">Desde</param>
        /// <param name="to">Hacia</param>
        /// <param name="asunto">Asunto</param>
        /// <param name="cuerpo">Cuerpo</param>
        public static void SendEmail(ConfigEmail configEmail, string from, string to, 
            string asunto, string cuerpo)
        {
            SendEmail(configEmail.NombreUsuario, configEmail.ClaveUsuario, 
                from, to, configEmail.IpServidor, configEmail.PuertoServidor, 
                asunto, cuerpo, configEmail.Ssl);
        }
    }
}
