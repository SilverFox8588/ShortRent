using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SF.Common
{
    public static class Utils
    {
        public const char FieldDelimiter = '|';
        private const string _sessionKey = "SessionKey_SFLogin_";

        private static readonly string _password = "Bigfoot.WebApi";
        private static readonly byte[] _salt = Encoding.UTF8.GetBytes("Zion.Web.WebApi");

        public static string NewSessionKey(int userId, int expires)
        {
            StringBuilder buffer = new StringBuilder();

            buffer.Append(userId);
            buffer.Append(FieldDelimiter);
            buffer.Append(expires);
            buffer.Append(FieldDelimiter);
            buffer.Append(DateTime.Now);

            return Encrypt(buffer.ToString());
        }

        public static string VerifySessionKey(string sessionKey)
        {
            string sessionKeyText = Decrypt(sessionKey);
            if (!string.IsNullOrEmpty(sessionKeyText))
            {
                string[] tokens = sessionKeyText.Split(FieldDelimiter);
                if (tokens.Length == 3)
                {
                    if (tokens[1] == "0" || DateTime.Compare(DateTime.Parse(tokens[2]).AddMinutes(int.Parse(tokens[1])), DateTime.Now) > 0)
                    {
                        string login = tokens[1];
                        return string.Format("{0}{1}{2}", _sessionKey, FieldDelimiter, login);
                    }
                }
            }

            return null;
        }

        public static int RetrieveUserId(string sessionKey)
        {
            string sessionKeyText = Decrypt(sessionKey);
            if (!string.IsNullOrEmpty(sessionKeyText))
            {
                string[] tokens = sessionKeyText.Split(FieldDelimiter);
                if (tokens.Length == 3)
                {
                    return int.Parse(tokens[0]);
                }
            }
            return 0;
        }

        private static string Encrypt(string text)
        {
            Rfc2898DeriveBytes passwordBytes = new Rfc2898DeriveBytes(_password, _salt);

            SymmetricAlgorithm encryptor = Rijndael.Create();
            encryptor.Key = passwordBytes.GetBytes(encryptor.KeySize / 8);
            encryptor.IV = passwordBytes.GetBytes(encryptor.BlockSize / 8);
            encryptor.Padding = PaddingMode.PKCS7;

            string encryptedText;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms,
                    encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] textBytes = Encoding.UTF8.GetBytes(text);
                    cs.Write(textBytes, 0, textBytes.Length);
                    cs.Close();
                }

                encryptedText = Convert.ToBase64String(ms.ToArray());
            }

            return encryptedText;
        }

        /// <summary>
        /// Decrypt a text.
        /// </summary>
        /// <param name="encryptedText">Text to be decrypted</param>
        /// <returns>Decrypted text.</returns>
        private static string Decrypt(string encryptedText)
        {
            Rfc2898DeriveBytes passwordBytes = new Rfc2898DeriveBytes(_password, _salt);

            SymmetricAlgorithm encryptor = Rijndael.Create();
            encryptor.Key = passwordBytes.GetBytes(encryptor.KeySize / 8);
            encryptor.IV = passwordBytes.GetBytes(encryptor.BlockSize / 8);
            encryptor.Padding = PaddingMode.PKCS7;

            string text;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms,
                    encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    byte[] encryptedTextBytes = Convert.FromBase64String(encryptedText);
                    cs.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
                    cs.Close();
                }

                text = Encoding.UTF8.GetString(ms.ToArray());
            }

            return text;
        }
    }
}
