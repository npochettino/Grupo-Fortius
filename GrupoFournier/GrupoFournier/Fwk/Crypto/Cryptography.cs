using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Fwk.Crypto
{
    public static class Cryptography
    {

        #region Const

        //private const string sharedSecret = "encriptedkey123";
        private static string sharedSecret = GetSharedSecret();
        private const string chars = "o6806642kbM7c5";
        private static byte[] _salt = Encoding.ASCII.GetBytes(chars);

        #endregion

        #region Methods

        /// <summary>
        /// Encripta texto.
        /// </summary>
        /// <param name="plainText">Texto plano</param>
        /// <param name="sharedSecret">Clave de encriptacion</param>
        /// <returns></returns>
        public static String Encrypt(String plainText)
        {

            #region Encrypt

            if (String.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            if (String.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            string outStr = null;                       // Encrypted string to return
            RijndaelManaged aesAlg = null;              // RijndaelManaged object used to encrypt the data.

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                // Create a RijndaelManaged object
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

                // Create a decryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // prepend the IV

                    //random first bytes to preprend
                    byte[] bytes = new byte[aesAlg.IV.Length];
                    new Random().NextBytes(bytes);
                    msEncrypt.Write(bytes, 0, sizeof(int));

                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            #endregion

            // -- Retorna texto encriptado.
            return outStr;
        }

        /// <summary>
        /// Desencripta texto.
        /// </summary>
        /// <param name="cipherText">Texto Cifrado</param>
        /// <param name="sharedSecret">Clave de encriptacion</param>
        /// <returns></returns>
        public static String Decrypt(String cipherText)
        {

            #region Decrypt

            if (String.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
            if (String.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            String plaintext = null;

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

                // Create the streams used for decryption.                
                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    // Create a RijndaelManaged object
                    // with the specified key and IV.
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    // Get the initialization vector from the encrypted stream
                    aesAlg.IV = ReadByteArray(msDecrypt);
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            #endregion

            // -- Retorna texto plano.
            return plaintext;
        }

        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }
            //el tamaño del vector debe ser de 16
            byte[] buffer = new byte[sizeof(int) * 4];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }

        #endregion

        private static string GetSharedSecret()
        {
            //string secretKey = WebConfigurationManager.AppSettings["secretKey"];
            string secretKey = "masterOfKey";
            return secretKey;
        }

    }
}
