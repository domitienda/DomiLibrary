using System.IO;
using System.Net.Sockets;
using System.Text;

namespace DomiLibrary.Utility.Network
{
    public class Tools
    {
        /// <summary>
        /// Gets the whois information.
        /// http://dotnet-snippets.com/dns/gets-the-whois-information-SID581.aspx
        /// Author: Jan Welker 
        /// </summary>
        /// <param name="whoisServer">The whois server.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static string GetWhoisInformation(string whoisServer, string url)
        {
            var stringBuilderResult = new StringBuilder();
            var tcpClinetWhois = new TcpClient(whoisServer, 43);
            var networkStreamWhois = tcpClinetWhois.GetStream();
            var bufferedStreamWhois = new BufferedStream(networkStreamWhois);
            var streamWriter = new StreamWriter(bufferedStreamWhois);

            streamWriter.WriteLine(url);
            streamWriter.Flush();

            var streamReaderReceive = new StreamReader(bufferedStreamWhois);

            while (!streamReaderReceive.EndOfStream)
                stringBuilderResult.AppendLine(streamReaderReceive.ReadLine());

            return stringBuilderResult.ToString();
        }
    }
}
