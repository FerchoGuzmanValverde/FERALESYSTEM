using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MateriaPrima
    {
        #region Atributos y Propiedades de la clase
        /// <summary>
        /// ID de la materia prima
        /// </summary>
        public short IdMateria { get; set; }
        /// <summary>
        /// Nombre de la materia prima
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Stock de la maeteria prima
        /// </summary>
        public short Stock { get; set; }
        /// <summary>
        /// Cantidad minima en stock
        /// </summary>
        public byte CantidadMinima { get; set; }
        /// <summary>
        /// Fecha del ultimo dia de reposicion de la materia prima
        /// </summary>
        public DateTime UltimoDiaReposicion { get; set; }
        /// <summary>
        /// Unidad de medida de la materia prima
        /// </summary>
        public string UnidadMedida { get; set; }
        /// <summary>
        ///Estado de la materia prima
        /// </summary>
        public byte Estado { get; set; }
        /// <summary>
        /// ID del almacen
        /// </summary>
        public byte IdAlmacen { get; set; }

        #endregion

        #region Constructores de la clase

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public MateriaPrima()
        {

        }

        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="IdMateria"></param>
        /// <param name="Nombre"></param>
        /// <param name="Stock"></param>
        /// <param name="CantidadMinima"></param>
        /// <param name="UltimoDiaReposicion"></param>
        /// <param name="UnidadMedida"></param>
        /// <param name="IdAlmacen"></param>
        public MateriaPrima(short IdMateria, string Nombre, short Stock, byte CantidadMinima, DateTime UltimoDiaReposicion, string UnidadMedida, byte Estado, byte IdAlmacen)
        {
            this.IdMateria = IdMateria;
            this.Nombre = Nombre;
            this.Stock = Stock;
            this.CantidadMinima = CantidadMinima;
            this.UltimoDiaReposicion = UltimoDiaReposicion;
            this.UnidadMedida = UnidadMedida;
            this.Estado = Estado;
            this.IdAlmacen = IdAlmacen;
        }

        /// <summary>
        /// Constructor para el INSERTAR
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Stock"></param>
        /// <param name="CantidadMinima"></param>
        /// <param name="UltimoDiaReposicion"></param>
        /// <param name="UnidadMedida"></param>
        /// <param name="IdAlmacen"></param>
        public MateriaPrima(string Nombre, short Stock, byte CantidadMinima, DateTime UltimoDiaReposicion, string UnidadMedida, byte IdAlmacen)
        {
            this.Nombre = Nombre;
            this.Stock = Stock;
            this.CantidadMinima = CantidadMinima;
            this.UltimoDiaReposicion = UltimoDiaReposicion;
            this.UnidadMedida = UnidadMedida;
            this.IdAlmacen = IdAlmacen;
        }

        #endregion
    }
}
