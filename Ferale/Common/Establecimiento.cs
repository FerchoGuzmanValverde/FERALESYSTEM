using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de la clase ESTABLECIMIENTO
    /// </summary>
    public class Establecimiento
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID del establecimiento
        /// </summary>
        public byte IdEstablecimiento { get; set; }
        /// <summary>
        /// Nombre del establecimiento
        /// </summary>
        public string NombreEstablecimiento { get; set; }
        /// <summary>
        /// Latitud de la ubicacion del establecimiento
        /// </summary>
        public float Latitud { get; set; }
        /// <summary>
        /// Longitud de la ubicacion del establecimiento
        /// </summary>
        public float Longitud { get; set; }
        /// <summary>
        /// Estado del establecimiento
        /// </summary>
        public byte Estado { get; set; }

        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Establecimiento()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idEstablecimiento"></param>
        /// <param name="nombre"></param>
        /// <param name="ubicacion"></param>
        public Establecimiento(byte idEstablecimiento, string nombre, float latitud, float longitud, byte estado)
        {
            this.IdEstablecimiento = idEstablecimiento;
            this.NombreEstablecimiento = nombre;
            this.Latitud = latitud;
            this.Longitud = longitud;
            this.Estado = estado;
        }
        /// <summary>
        /// Constructor para el INSERT
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="ubicacion"></param>
        public Establecimiento(string nombre, float latitud, float longitud)
        {
            this.NombreEstablecimiento = nombre;
            this.Latitud = latitud;
            this.Longitud = longitud;
        }

        #endregion
    }
}
