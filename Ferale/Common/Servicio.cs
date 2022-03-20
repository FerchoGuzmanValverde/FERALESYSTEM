using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de SERVICIO
    /// </summary>
    public class Servicio
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID del servicio
        /// </summary>
        public short IdServicio { get; set; }
        /// <summary>
        /// Nombre del servicio
        /// </summary>
        public string NombreServicio { get; set; }
        /// <summary>
        /// Unidad de medida del servicio
        /// </summary>
        public string UnidadMedida { get; set; }
        /// <summary>
        /// Estado del servicio
        /// </summary>
        public byte Estado { get; set; }

        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Servicio()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idServicio"></param>
        /// <param name="nombreServicio"></param>
        /// <param name="unidadMedida"></param>
        /// <param name="estado"></param>
        public Servicio(short idServicio, string nombreServicio, string unidadMedida, byte estado)
        {
            this.IdServicio = idServicio;
            this.NombreServicio = nombreServicio;
            this.UnidadMedida = unidadMedida;
            this.Estado = estado;

        }
        /// <summary>
        /// Constructor para el INSERT
        /// </summary>
        /// <param name="nombreServicio"></param>
        /// <param name="unidadMedida"></param>
        public Servicio(string nombreServicio, string unidadMedida)
        {
            this.NombreServicio = nombreServicio;
            this.UnidadMedida = unidadMedida;
        }

        #endregion
    }
}
