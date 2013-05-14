using System.Collections.Generic;
using System.IO;
using System.Net;
using DomiLibrary.Utility.Helper;

namespace DomiLibrary.Utility.Email
{
    /// <summary>
    /// Clase que nos permite enviar emails, cuyo contenido se genera
    /// a partir de una plantilla
    /// </summary>
    public class EmailTemplate
    {
        private readonly ConfigEmail _configEmail;

        public EmailTemplate(ConfigEmail configEmail)
        {
            _configEmail = configEmail;
        }

        /// <summary>
        /// Construye el cuerpo del mensaje del email con la plantilla
        /// </summary>
        /// <param name="urlTemplate"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public string ContruirCuerpo(string urlTemplate, IDictionary<string, string> tags)
        {
            ValidationHelper.NotBlank(urlTemplate);
            ValidationHelper.NotNull(tags);

            var request = WebRequest.Create(urlTemplate);
            request.Timeout = 30 * 60 * 1000;
            request.UseDefaultCredentials = true;
            request.Proxy.Credentials = request.Credentials;
            var response = request.GetResponse();

            string cuerpo;
            if (response.GetResponseStream() == null) return null;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                cuerpo = reader.ReadToEnd();
            }

            foreach (var tag in tags)
            {
                cuerpo = cuerpo.Replace("{" + tag.Key + "}", tag.Value);
            }

            return cuerpo;
        }

        public void EnviarEmail(string from, string to, string asunto, string cuerpo)
        {
            ValidationHelper.NotBlank(from);
            ValidationHelper.NotBlank(to);

            EmailHelper.SendEmail(_configEmail, from, to, asunto, cuerpo);
        }
    }
}
