using System.Security.Cryptography;
using System.Text;

namespace SeniorChallenge.Utilities
{
    /// <summary>
    /// utility to define encryption parameters.
    /// </summary>
    public static class UtilEncrypter
    {
        private static readonly byte[] MAJOR_KEY = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("KEY").ToString());
        private static readonly byte[] KEY = MAJOR_KEY.Reverse().Skip(MAJOR_KEY.Length - 32).ToArray();
        private static readonly byte[] IV = MAJOR_KEY.Skip(MAJOR_KEY.Length - 16).ToArray();

        internal static byte[] GetByteKey()
        {
            return MAJOR_KEY;
        }

        /// <summary>
        /// performs encryption of the value entered.
        /// </summary>
        /// <param name="texto">The text will be encrypted.</param>
        /// <returns>The encrypted text</returns>
        public static string Encrypt(string texto)
        {
            MemoryStream memoryStream = new();
            CryptoStream cryptoStream = new(memoryStream, Aes.Create().CreateEncryptor(KEY, IV), CryptoStreamMode.Write);
            StreamWriter streamWriter = new(cryptoStream);
            streamWriter.WriteLine(texto);
            streamWriter.Close();
            cryptoStream.Close();
            byte[] inArray = memoryStream.ToArray();
            memoryStream.Close();
            return Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// performs dencryption of the value entered.
        /// </summary>
        /// <param name="texto">The text will be dencrypted.</param>
        /// <returns>The dencrypted text.</returns>
        public static string Decrypt(string texto)
        {
            MemoryStream memoryStream = new(Convert.FromBase64String(texto));
            CryptoStream cryptoStream = new(memoryStream, Aes.Create().CreateDecryptor(KEY, IV), CryptoStreamMode.Read);
            StreamReader streamReader = new(cryptoStream);
            string result = streamReader.ReadLine();
            streamReader.Close();
            cryptoStream.Close();
            memoryStream.Close();
            return result;
        }
    }
}
