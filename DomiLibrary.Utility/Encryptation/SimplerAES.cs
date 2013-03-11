using System;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.IO;

namespace DomiLibrary.Utility.Encryptation
{
    /// <summary>
    /// Clase que encripta en Simple AES
    /// </summary>
    public class SimplerAes
    {
        private static readonly byte[] Key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };
        private static readonly byte[] Vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 221, 112, 79, 32, 114, 156 };
        private readonly ICryptoTransform _encryptor;
        private readonly ICryptoTransform _decryptor;
        private readonly UTF8Encoding _encoder;

        public SimplerAes()
        {
            var rm = new RijndaelManaged();
            _encryptor = rm.CreateEncryptor(Key, Vector);
            _decryptor = rm.CreateDecryptor(Key, Vector);
            _encoder = new UTF8Encoding();
        }

        /// <summary>
        /// Encripta un string
        /// </summary>
        /// <param name="unencrypted">Parametro a encriptar</param>
        /// <returns>Cadena encriptada</returns>
        public string Encrypt(string unencrypted)
        {
            return Convert.ToBase64String(Encrypt(_encoder.GetBytes(unencrypted)));
        }

        /// <summary>
        /// Desencripta un string
        /// </summary>
        /// <param name="encrypted">Parametro a desencriptar</param>
        /// <returns>Cadena desencriptada</returns>
        public string Decrypt(string encrypted)
        {
            return _encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)));
        }

        /// <summary>
        /// Encripta una url
        /// </summary>
        /// <param name="unencrypted">Url a encriptar</param>
        /// <returns>Url encriptada</returns>
        public string EncryptToUrl(string unencrypted)
        {
            return HttpUtility.UrlEncode(Encrypt(unencrypted));
        }

        /// <summary>
        /// Desencripta una url
        /// </summary>
        /// <param name="encrypted">Url encriptada</param>
        /// <returns>Url desencriptada</returns>
        public string DecryptFromUrl(string encrypted)
        {
            return Decrypt(HttpUtility.UrlDecode(encrypted));
        }

        /// <summary>
        /// Encripta un array de bytes
        /// </summary>
        /// <param name="buffer">array de bytes para encriptar</param>
        /// <returns>array de bytes encriptados</returns>
        public byte[] Encrypt(byte[] buffer)
        {
            return Transform(buffer, _encryptor);
        }

        /// <summary>
        /// Desencripta un array de bytes
        /// </summary>
        /// <param name="buffer">array de bytes para desencriptar</param>
        /// <returns>array de bytes desencriptados</returns>
        public byte[] Decrypt(byte[] buffer)
        {
            return Transform(buffer, _decryptor);
        }

        protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            var stream = new MemoryStream();
            using (var cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return stream.ToArray();
        }
    }
}
