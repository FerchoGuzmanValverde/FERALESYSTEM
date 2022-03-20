using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de la clase TipoLimpieza
    /// </summary>
    public class TipoLimpieza
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID tipo limpieza
        /// </summary>
        public byte IdTipoLimpieza { get; set; }
        /// <summary>
        /// Nombre del tipo de limpieza
        /// </summary>
        public string NombreTipo { get; set; }
        /// <summary>
        /// Estado del tipo de la limpieza
        /// </summary>
        public byte Estado { get; set; }

        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public TipoLimpieza()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idTipoLimpieza"></param>
        /// <param name="nombreTipoLimpieza"></param>
        /// <param name="estado"></param>
        public TipoLimpieza(byte idTipoLimpieza, string nombreTipoLimpieza, byte estado)
        {
            this.IdTipoLimpieza = idTipoLimpieza;
            this.NombreTipo = nombreTipoLimpieza;
            this.Estado = estado;
        }
        /// <summary>
        /// Constructor para el Obtener
        /// </summary>
        /// <param name="nombreTipoLimpieza"></param>
        public TipoLimpieza(string nombreTipoLimpieza)
        {
            this.NombreTipo = nombreTipoLimpieza;
        }

        #endregion
    }
}
