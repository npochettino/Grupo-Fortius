using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fwk.Crypto
{
    /// <summary>
    /// Clase que provee funcionalidad Hash.
    /// </summary>
    public static class Hash
    {
        /// <summary>
        /// Retorna un hash en base a un String.
        /// </summary>
        /// <param name="str">string a partir del cual generaremos el Hash</param>
        /// <returns>Hash</returns>
        public static string Generate(string str)
        {
            Encoder enc = System.Text.Encoding.Unicode.GetEncoder();
            byte[] unicodeText = new byte[str.Length * 2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(unicodeText);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}
