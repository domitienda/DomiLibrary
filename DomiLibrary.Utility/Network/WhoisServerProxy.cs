namespace DomiLibrary.Utility.Network
{
    public class WhoisServerProxy
    {
        public static string Proxy(string extension)
        {
            var result = string.Empty;

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
