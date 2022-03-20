using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de VentaDetalle
    /// </summary>
    public class VentaDetalle
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID  de la venta
        /// </summary>
        public int IdVenta { get; set; }
        /// <summary>
        /// ID del producto
        /// </summary>
        public short IdProducto { get; set; }
        /// <summary>
        /// Descripcion del Producto
        /// </summary>
        public string DescripcionProducto { get; set; }
        /// <summary>
        /// Cantidad del producto
        /// </summary>
        public short Cantidad { get; set; }
        /// <summary>
        /// Precio venta del producto
        /// </summary>
        public double PrecioUnitario { get; set; }
        /// <summary>
        /// Estado del Detalle
        /// </summary>
        public byte Estado { get; set; }

        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public VentaDetalle()
        {

        }
        /// <summary>
        /// Constructor para el GET y el INSERT
        /// </summary>
        /// <param name="idVenta"></param>
        /// <param name="idProducto"></param>
        /// <param name="cantidad"></param>
        /// <param name="precioUnitario"></param>
        public VentaDetalle(int idVenta, short idProducto, short cantidad, double precioUnitario)
        {
            this.IdVenta = idVenta;
            this.IdProducto = idProducto;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
        }
        /// <summary>
        /// Constructor para el GET con nombre de producto
        /// </summary>
        /// <param name="idVenta"></param>
        /// <param name="idProducto"></param>
        /// <param name="descripcion"></param>
        /// <param name="cantidad"></param>
        /// <param name="precioUnitario"></param>
        /// <param name="estado"></param>
        public VentaDetalle(int idVenta, short idProducto, string descripcion, short cantidad, double precioUnitario, byte estado)
        {
            this.IdVenta = idVenta;
            this.IdProducto = idProducto;
            this.DescripcionProducto = descripcion;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
            this.Estado = estado;
        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idVenta"></param>
        /// <param name="idProducto"></param>
        /// <param name="cantidad"></param>
        /// <param name="precioUnitario"></param>
        /// <param name="estado"></param>
        public VentaDetalle(int idVenta, short idProducto, short cantidad, double precioUnitario, byte estado)
        {
            this.IdVenta = idVenta;
            this.IdProducto = idProducto;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
            this.Estado = estado;
        }

        #endregion
    }
}
