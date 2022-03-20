using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de almacen
    /// </summary>
    public class Almacen
    {
        #region Atributos y Propiedades de la clase
        /// <summary>
        /// ID del Almacen
        /// </summary>
        public byte IdAlmacen { get; set; }
        /// <summary>
        /// Nombre del almacen
        /// </summary>
        public string NombreAlmacen { get; set; }
        /// <summary>
        /// Latitud de la ubicacion del almacen
        /// </summary>
        public float Latitud { get; set; }
        /// <summary>
        /// Longitud de la ubicacion del almacen
        /// </summary>
        public float Longitud { get; set; }
        /// <summary>
        /// Direccin literal del almacen
        /// </summary>
        public string Direccion { get; set; }
        /// <summary>
        /// Estado del almacen
        /// </summary>
        public byte Estado { get; set; }

        #endregion

        #region Constructores de la clase

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Almacen()
        {

        }

        /// <summary>
        /// Contructor get
        /// </summary>
        /// <param name="IdAlmacen"></param>
        /// <param name="NombreAlmacen"></param>
        /// <param name="Latitud"></param>
        /// <param name="Longitud"></param>
        /// <param name="Direccion"></param>
        /// <param name="Estado"></param>
        public Almacen(byte IdAlmacen, string NombreAlmacen, float Latitud, float Longitud, string Direccion, byte Estado)
        {
            this.IdAlmacen = IdAlmacen;
            this.NombreAlmacen = NombreAlmacen;
            this.Latitud = Latitud;
            this.Longitud = Longitud;
            this.Direccion = Direccion;
            this.Estado = Estado;
        }

        /// <summary>
        /// Constructor para el INSERTAR
        /// </summary>
        /// <param name="NombreAlmacen"></param>
        public Almacen(string NombreAlmacen, float Latitud, float Longitud, string Direccion)
        {
            this.NombreAlmacen = NombreAlmacen;
            this.Latitud = Latitud;
            this.Longitud = Longitud;
            this.Direccion = Direccion;
        }

        #endregion
    }
}
