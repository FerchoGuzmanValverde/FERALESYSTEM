using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de TipoProducto
    /// </summary>
    public class TipoProducto
    {
        #region Atributos y Propiedades de la clase
        /// <summary>
        /// ID del tipo producto
        /// </summary>
        public byte IdTipoProducto { get; set; }
        /// <summary>
        /// Nombre del tipo producto
        /// </summary>
        public string NombreTipo { get; set; }
        /// <summary>
        /// Estado del tipo producto
        /// </summary>
        public byte Estado { get; set; }

        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public TipoProducto()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idTipoProducto"></param>
        /// <param name="nombreTipo"></param>
        /// <param name="estado"></param>
        public TipoProducto(byte idTipoProducto, string nombreTipo, byte estado)
        {
            this.IdTipoProducto = idTipoProducto;
            this.NombreTipo = nombreTipo;
            this.Estado = estado;
        }
        /// <summary>
        /// Constructor para el Obtener
        /// </summary>
        /// <param name="nombreTipo"></param>
        public TipoProducto(string nombreTipo)
        {
            this.NombreTipo = nombreTipo;
        }

        #endregion
    }
}
