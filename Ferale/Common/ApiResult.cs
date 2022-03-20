using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para los resultados del API
    /// </summary>
    public class ApiResults
    {
        #region Atributos
        /// <summary>
        /// Access token
        /// </summary>
        public string Accesstoken { get; set; }
        /// <summary>
        /// Fecha de expiracion del token
        /// </summary>
        public DateTime Tokenexpires { get; set; }
        /// <summary>
        /// Granted Scopes
        /// </summary>
        public string GrantedScopes { get; set; }
        /// <summary>
        /// Denied Scopes
        /// </summary>
        public string DeniedScopes { get; set; }
        /// <summary>
        /// Mensaje de error
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// Razon del error
        /// </summary>
        public string ErrorReason { get; set; }
        /// <summary>
        /// Descripcion del error
        /// </summary>
        public string ErrorDescription { get; set; }
        /// <summary>
        /// Bandera de error encontrado
        /// </summary>
        public bool ErrorFound { get; set; } = false;
        #endregion
    }
}
