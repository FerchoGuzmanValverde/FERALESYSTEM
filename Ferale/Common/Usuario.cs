using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Common
{
    /// <summary>
    /// Clase para crear usuarios
    /// </summary>
    public class Usuario
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID del usuario
        /// </summary>
        public int IdUsuario { get; set; }
        /// <summary>
        /// Rol del usuario
        /// </summary>
        public string Rol { get; set; }
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string NombreUsuario { get; set; }
        /// <summary>
        /// Contraseña del usuario en MD5
        /// </summary>
        public string PasswordUsuario { get; set; }
        /// <summary>
        /// Estado del usuario
        /// </summary>
        public byte Estado { get; set; }
        /// <summary>
        /// Configuraciones del usuario
        /// </summary>
        public byte Settings { get; set; }
        /// <summary>
        /// Correo del usuario
        /// </summary>
        public string Correo { get; set; }
        /// <summary>
        /// Codigo del usuario en MD5
        /// </summary>
        public string Codigo { get; set; }
        #endregion


        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Usuario()
        {

        }

        /// <summary>
        /// Constructor para el Insert
        /// </summary>
        /// <param name="Rol"></param>
        /// <param name="NombreUsuario"></param>
        /// <param name="PasswordUsuario"></param>
        /// <param name="Settings"></param>
        /// <param name="Correo"></param>
        /// <param name="Codigo"></param>
        public Usuario(string Rol, string NombreUsuario, string PasswordUsuario, byte Settings, string Correo, string Codigo)
        {
            this.Rol = Rol;
            this.NombreUsuario = NombreUsuario;
            this.PasswordUsuario = PasswordUsuario;
            this.Settings = Settings;
            this.Correo = Correo;
            this.Codigo = Codigo;
        }

        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="Rol"></param>
        /// <param name="NombreUsuario"></param>
        /// <param name="PasswordUsuario"></param>
        /// <param name="Settings"></param>
        /// <param name="Correo"></param>
        /// <param name="Codigo"></param>
        /// <param name="Estado"></param>
        public Usuario(int IdUsuario, string Rol, string NombreUsuario, string PasswordUsuario, byte Settings, string Correo, string Codigo, byte Estado)
        {
            this.IdUsuario = IdUsuario;
            this.Rol = Rol;
            this.NombreUsuario = NombreUsuario;
            this.PasswordUsuario = PasswordUsuario;
            this.Settings = Settings;
            this.Correo = Correo;
            this.Codigo = Codigo;
            this.Estado = Estado;
        }

        #endregion
    }
}
