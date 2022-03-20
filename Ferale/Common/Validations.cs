using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para metodos de validacion de campos
    /// </summary>
    public class Validations
    {
        #region Metodos
        /// <summary>
        /// Metodo para validar solo letras
        /// </summary>
        /// <param name="cad"></param>
        /// <returns>Bool</returns>
        public static bool OnlyLetters(string cad)
        {
            for (int i = 0; i < cad.Length; i++)
            {
                if (!Char.IsLetter(cad[i]))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Metodo para validar solo números
        /// </summary>
        /// <param name="cad"></param>
        /// <returns>Bool</returns>
        public static bool OnlyNumbers(string cad)
        {
            for (int i = 0; i < cad.Length; i++)
            {
                if (!Char.IsNumber(cad[i]))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Metodo para validar solo letras y espacios
        /// </summary>
        /// <param name="cad"></param>
        /// <returns>Bool</returns>
        public static bool OnlyLettersAndSpaces(string cad)
        {
            for (int i = 0; i < cad.Length; i++)
            {
                if (!Char.IsLetter(cad[i]) && cad[i]!=' ')
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Metodo para validar solo numeros y simbolos
        /// </summary>
        /// <param name="cad"></param>
        /// <returns>Bool</returns>
        public static bool OnlyNumbersAndSeparators(string cad)
        {
            for (int i = 0; i < cad.Length; i++)
            {
                if (!Char.IsNumber(cad[i]) && !Char.IsSymbol(cad[i]))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Metodo para validar solo precios
        /// </summary>
        /// <param name="cad"></param>
        /// <returns>Bool</returns>
        public static bool Precios(string cad)
        {
            for (int i = 0; i < cad.Length; i++)
            {
                if (!Char.IsNumber(cad[i]) && cad[i] != '.')
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Metodo para validar solo cadenas
        /// </summary>
        /// <param name="cad"></param>
        /// <returns>Bool</returns>
        public static bool RazonSocial(string cad)
        {
            for (int i = 0; i < cad.Length; i++)
            {
                if (!Char.IsLetter(cad[i]) && cad[i] != ' ')
                {
                    return false;
                }
            }
            if (cad.Length < 5 || cad.Length > 100)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Método para validar solo nit
        /// </summary>
        /// <param name="cad"></param>
        /// <returns>Bool</returns>
        public static bool Nit(string cad)
        {
            for (int i = 0; i < cad.Length; i++)
            {
                if (!Char.IsNumber(cad[i]) && !Char.IsLetter(cad[i]))
                {
                    return false;
                }
            }
            if (cad.Length < 7 || cad.Length > 15)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Metodo para validar fechas de nacimiento
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool DateOfBirth(DateTime dt)
        {
            if (dt.Year > DateTime.Now.Year && dt.Month > DateTime.Now.Month && dt.Day > DateTime.Now.Day && dt.Hour > DateTime.Now.Hour && dt.Minute > DateTime.Now.Minute)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Metodo para validar usuarios
        /// </summary>
        /// <param name="cad"></param>
        /// <returns></returns>
        public static bool Users(string cad)
        {
            for (int i = 0; i < cad.Length; i++)
            {
                if (!Char.IsNumber(cad[i]) && !Char.IsLetter(cad[i]))
                {
                    return false;
                }
            }
            if (cad.Length < 3 || cad.Length > 15)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Metodo para validar contraseñas
        /// </summary>
        /// <param name="cad"></param>
        /// <returns></returns>
        public static bool Password(string cad)
        {
            for (int i = 0; i < cad.Length; i++)
            {
                if (!Char.IsNumber(cad[i]) && !Char.IsLetter(cad[i]))
                {
                    return false;
                }
            }
            if (cad.Length < 3)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Metodo para validar emails
        /// </summary>
        /// <param name="cad"></param>
        /// <returns></returns>
        public static bool Emails(string cad)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (!Regex.IsMatch(cad, expresion))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
