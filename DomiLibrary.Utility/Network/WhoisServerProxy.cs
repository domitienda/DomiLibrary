namespace DomiLibrary.Utility.Network
{
    /// <summary>
    /// Proxy WhoisServer
    /// </summary>
    public class WhoisServerProxy
    {
        /// <summary>
        /// Devuelve el server whois asociado a la extension
        /// </summary>
        /// <param name="extension">Extension</param>
        /// <returns>Nombre del servidor de whois</returns>
        public static string Proxy(string extension)
        {
            string result;

            switch (extension)
            {
                case "com":
                    {
                        result = WhoisServerEnum.com;
                        break;
                    }
                case "net":
                    {
                        result = WhoisServerEnum.net;
                        break;
                    }
                case "org":
                    {
                        result = WhoisServerEnum.org;
                        break;
                    }
                case "info":
                    {
                        result = WhoisServerEnum.info;
                        break;
                    }
                case "ws":
                    {
                        result = WhoisServerEnum.ws;
                        break;
                    }
                case "me":
                    {
                        result = WhoisServerEnum.me;
                        break;
                    }
                case "eu":
                    {
                        result = WhoisServerEnum.eu;
                        break;
                    }
                case "biz":
                    {
                        result = WhoisServerEnum.biz;
                        break;
                    }
                case "us":
                    {
                        result = WhoisServerEnum.us;
                        break;
                    }
                default:
                    {
                        result = WhoisServerEnum.com;
                        break;
                    }
            }

            return result;
        }
    }
}
