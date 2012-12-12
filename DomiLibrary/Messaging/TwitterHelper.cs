using Twitterizer;

namespace DomiLibrary.Messaging
{
    /// <summary>
    /// Clase encargada de realizar la conexion con twitter
    /// </summary>
    public class TwitterHelper
    {
        private readonly string _accessToken;
        private readonly string _accessTokenSecret;
        private readonly string _consumerKey;
        private readonly string _consumerSecret;

        public TwitterHelper(string accessToken, string accessTokenSecret, string consumerKey, string consumerSecret)
        {
            _accessToken = accessToken;
            _accessTokenSecret = accessTokenSecret;
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
        }

        /// <summary>
        /// Metodo encargado de actualizar el estatus de la cuenta de twitter
        /// </summary>
        /// <param name="status"></param>
        public TwitterResponse<TwitterStatus> UpdateStatus(string status)
        {
            var authTokens = new OAuthTokens
                            {
                                AccessToken = _accessToken,
                                AccessTokenSecret = _accessTokenSecret,
                                ConsumerKey = _consumerKey,
                                ConsumerSecret = _consumerSecret
                            };

            if (status.Length > 140)
            {
                status = status.Substring(0, 140);
            }

            var response = TwitterStatus.Update(authTokens, status);
            return response;
        }
    }
}
