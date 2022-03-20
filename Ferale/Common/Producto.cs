using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de Producto
    /// </summary>
    public class Producto
    {
        #region Atributos y Propiedades de la clase
        /// <summary>
        /// ID del producto
        /// </summary>
        public short IdProducto { get; set; }
        /// <summary>
        /// Descripcion del producto
        /// </summary>
        public string DescripcionProducto { get; set; }
        /// <summary>
        /// Precio base del producto
        /// </summary>
        public double PrecioBase { get; set; }
        /// <summary>
        /// Estado del producto
        /// </summary>
        public byte Estado { get; set; }
        /// <summary>
        /// Foto del producto
        /// </summary>
        public byte[] Foto { get; set; }
        /// <summary>
        /// Indicaciones del producto
        /// </summary>
        public string Indicaciones { get; set; }
        /// <summary>
        /// Stock del producto
        /// </summary>
        public short Stock { get; set; }
        /// <summary>
        /// Variedad del producto
        /// </summary>
        public string Variedad { get; set; }
        /// <summary>
        /// ID del tipo de producto
        /// </summary>
        public byte IdTipoProducto { get; set; }

        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Producto()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idProducto"></param>
        /// <param name="descripcion"></param>
        /// <param name="precioBase"></param>
        /// <param name="estado"></param>
        /// <param name="foto"></param>
        /// <param name="indicaciones"></param>
        /// <param name="stock"></param>
        /// <param name="variedad"></param>
        /// <param name="idTipoProducto"></param>
        public Producto(short idProducto, string descripcion, double precioBase, byte estado, byte[] foto,string indicaciones, short stock, string variedad, byte idTipoProducto)
        {
            this.IdProducto = idProducto;
            this.DescripcionProducto = descripcion;
            this.PrecioBase = precioBase;
            this.Estado = estado;
            this.Foto = foto;
            this.Indicaciones = indicaciones;
            this.Stock = stock;
            this.Variedad = variedad;
            this.IdTipoProducto = idTipoProducto;
        }
        /// <summary>
        /// Constructor para el INSERT
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="precioBase"></param>
        /// <param name="foto"></param>
        /// <param name="indicaciones"></param>
        /// <param name="stock"></param>
        /// <param name="variedad"></param>
        /// <param name="idTipoProducto"></param>
        public Producto(string descripcion, double precioBase, byte[] foto, string indicaciones, short stock, string variedad, byte idTipoProducto)
        {
            this.DescripcionProducto = descripcion;
            this.PrecioBase = precioBase;
            this.Foto = foto;
            this.Indicaciones = indicaciones;
            this.Stock = stock;
            this.Variedad = variedad;
            this.IdTipoProducto = idTipoProducto;
        }

        #endregion
    }
}
