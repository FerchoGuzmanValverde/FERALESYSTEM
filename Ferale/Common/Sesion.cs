using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear sesiones
    /// </summary>
    public class Sesion
    {
        #region Atributos y propiedades
        /// <summary>
        /// ID del usuario
        /// </summary>
        public static int idUsuario;
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public static string nombreUsuario;
        /// <summary>
        /// Rol de la sesion
        /// </summary>
        public static string rolSesion;
        /// <summary>
        /// ID app facebook
        /// </summary>
        public static string idAppFacebook;
        #endregion
        #region Metodos
        /// <summary>
        /// Metodo ver info
        /// </summary>
        /// <returns>String</returns>
        public static string VerInfo()
        {
            return "Usuario: " + nombreUsuario + " || Rol: " + rolSesion;
        }
        #endregion
    }
}
