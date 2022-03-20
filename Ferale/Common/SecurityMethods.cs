using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para metodos de seguridad
    /// </summary>
    public class SecurityMethods
    {
        #region Metodos
        /// <summary>
        /// Metodo para generar el codigo de seguridad email
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="ci"></param>
        /// <returns>String</returns>
        public static string GenerarCodigo(string nombre, string ci)
        {
            Random num = new Random();
            string hash;
            string cad = nombre + ci + DateTime.Now.Year + num.Next(1000, 10000);
            
            using (MD5 md5Hash = MD5.Create())
            {
                hash = GetMd5Hash(md5Hash, cad.Substring(2));
            }

            return hash.Substring(3);
        }

        /// <summary>
        /// Metodo para encriptar una clave en MD5
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns>string</returns>
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        #endregion
    }
}
