using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de Produccion
    /// </summary>
    public class Produccion
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID de la produccion
        /// </summary>
        public int IdProduccion { get; set; }
        /// <summary>
        /// ID del producto
        /// </summary>
        public short IdProducto { get; set; }
        /// <summary>
        /// Cantidad de produccion
        /// </summary>
        public short Cantidad { get; set; }
        /// <summary>
        /// Fecha de produccion
        /// </summary>
        public DateTime FechaProduccion { get; set; }
        /// <summary>
        /// Fecha vencimiento de la produccion
        /// </summary>
        public DateTime FechaVencimiento { get; set; }
        /// <summary>
        /// ID del nro de lote
        /// </summary>
        public int IdLote { get; set; }
        /// <summary>
        /// Estado de la produccion
        /// </summary>
        public byte Estado { get; set; }

        /// <summary>
        /// Lista de materiales de la produccion
        /// </summary>
        public List<MateriaProduccion> Detalles { get; set; }

        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Produccion()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idProduccion"></param>
        /// <param name="idProducto"></param>
        /// <param name="cantidad"></param>
        /// <param name="fechaProduccion"></param>
        /// <param name="fechaVencimiento"></param>
        /// <param name="idLote"></param>
        /// <param name="estado"></param>
        /// <param name="detalles"></param>
        public Produccion(int idProduccion, short idProducto, short cantidad, DateTime fechaProduccion, DateTime fechaVencimiento, int idLote, byte estado, List<MateriaProduccion> detalles)
        {
            this.IdProduccion = idProduccion;
            this.IdProducto = idProducto;
            this.Cantidad = cantidad;
            this.FechaProduccion = fechaProduccion;
            this.FechaVencimiento = fechaVencimiento;
            this.IdLote = idLote;
            this.Estado = estado;
            this.Detalles = detalles;
        }
        /// <summary>
        /// Constructor para el INSERT
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="cantidad"></param>
        /// <param name="fechaVencimiento"></param>
        /// <param name="detalles"></param>
        public Produccion(short idProducto, short cantidad, DateTime fechaVencimiento, List<MateriaProduccion> detalles)
        {
            this.IdProducto = idProducto;
            this.Cantidad = cantidad;
            this.FechaVencimiento = fechaVencimiento;
            this.Detalles = detalles;
        }

        #endregion
    }
}
