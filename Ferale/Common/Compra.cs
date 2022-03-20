using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de Compra
    /// </summary>
    public class Compra
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID de la compra
        /// </summary>
        public int IdCompra { get; set; }
        /// <summary>
        /// Fecha y hora de la compra
        /// </summary>
        public DateTime FechaHoraCompra { get; set; }
        /// <summary>
        /// Monto total de la compra
        /// </summary>
        public double MontoTotalCompra { get; set; }
        /// <summary>
        /// Nro de factura de la compra
        /// </summary>
        public string NroFactura { get; set; }
        /// <summary>
        /// Nro de autorizacion de la compra
        /// </summary>
        public string NroAutorizacion { get; set; }
        /// <summary>
        /// Codigo de control de la compra
        /// </summary>
        public string CodigoControl { get; set; }
        /// <summary>
        /// ID del proveedor
        /// </summary>
        public short IdProveedor { get; set; }
        /// <summary>
        /// ID del empleado
        /// </summary>
        public int IdEmpleado { get; set; }
        /// <summary>
        /// Estado de la compra
        /// </summary>
        public byte Estado { get; set; }
        /// <summary>
        /// Lista del detalle de compra
        /// </summary>
        public List<CompraDetalle> Detalles { get; set; }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de la compra
        /// </summary>
        public Compra()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idCompra"></param>
        /// <param name="fechaHora"></param>
        /// <param name="montoTotal"></param>
        /// <param name="nroFactura"></param>
        /// <param name="nroAutorizacion"></param>
        /// <param name="codigoControl"></param>
        /// <param name="idProveedor"></param>
        /// <param name="idEmpleado"></param>
        /// <param name="estado"></param>
        public Compra(int idCompra, DateTime fechaHora, double montoTotal, string nroFactura, string nroAutorizacion, string codigoControl, short idProveedor, int idEmpleado, byte estado, List<CompraDetalle> detalles)
        {
            this.IdCompra = idCompra;
            this.FechaHoraCompra = fechaHora;
            this.MontoTotalCompra = montoTotal;
            this.NroFactura = nroFactura;
            this.NroAutorizacion = nroAutorizacion;
            this.CodigoControl = codigoControl;
            this.IdProveedor = idProveedor;
            this.IdEmpleado = idEmpleado;
            this.Estado = estado;
            this.Detalles = detalles;
        }
        /// <summary>
        /// Constructor para el INSERT
        /// </summary>
        /// <param name="montoTotal"></param>
        /// <param name="nroFactura"></param>
        /// <param name="nroAutorizacion"></param>
        /// <param name="codigoControl"></param>
        /// <param name="idProveedor"></param>
        /// <param name="idEmpleado"></param>
        public Compra(double montoTotal, string nroFactura, string nroAutorizacion, string codigoControl, short idProveedor, int idEmpleado, List<CompraDetalle> detalles)
        {
            this.MontoTotalCompra = montoTotal;
            this.NroFactura = nroFactura;
            this.NroAutorizacion = nroAutorizacion;
            this.CodigoControl = codigoControl;
            this.IdProveedor = idProveedor;
            this.IdEmpleado = idEmpleado;
            this.Detalles = detalles;
        }

        #endregion
    }
}
