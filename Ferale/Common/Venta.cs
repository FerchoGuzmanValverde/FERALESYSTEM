using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de VENTA
    /// </summary>
    public class Venta
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID de la venta
        /// </summary>
        public int IdVenta { get; set; }
        /// <summary>
        /// Fecha hora de la venta
        /// </summary>
        public DateTime FechaHoraVenta { get; set; }
        /// <summary>
        /// Fecha hora del pedido
        /// </summary>
        public DateTime FechaHoraPedido { get; set; }
        /// <summary>
        /// Monto total de la venta
        /// </summary>
        public double MontoTotalVenta { get; set; }
        /// <summary>
        /// Descuento en porcentaje de la venta
        /// </summary>
        public byte Descuento { get; set; }
        /// <summary>
        /// Estado de la entrega de la venta
        /// </summary>
        public byte EstadoEntrega { get; set; }
        /// <summary>
        /// Adelanto de la venta
        /// </summary>
        public double Adelanto { get; set; }
        /// <summary>
        /// Estado de la venta
        /// </summary>
        public byte Estado { get; set; }
        /// <summary>
        /// ID del cliente
        /// </summary>
        public int IdCliente { get; set; }
        /// <summary>
        /// ID del empleado
        /// </summary>
        public int IdEmpleado { get; set; }
        /// <summary>
        /// Lista del detalle de la venta
        /// </summary>
        public List<VentaDetalle> Detalles { get; set; }

        #endregion
        #region Construtores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Venta()
        {

        }
        /// <summary>
        /// Constructor para el GET VENTA
        /// </summary>
        /// <param name="idVenta"></param>
        /// <param name="fechaHoraVenta"></param>
        /// <param name="montoTotal"></param>
        /// <param name="descuento"></param>
        /// <param name="estadoEntrega"></param>
        /// <param name="adelanto"></param>
        /// <param name="estado"></param>
        /// <param name="idCliente"></param>
        /// <param name="idEmpleado"></param>
        public Venta(int idVenta, DateTime fechaHoraVenta, double montoTotal, byte descuento, byte estadoEntrega, double adelanto, byte estado, int idCliente, int idEmpleado, List<VentaDetalle> detalles)
        {
            this.IdVenta = idVenta;
            this.FechaHoraVenta = fechaHoraVenta;
            this.MontoTotalVenta = montoTotal;
            this.Descuento = descuento;
            this.EstadoEntrega = estadoEntrega;
            this.Adelanto = adelanto;
            this.Estado = estado;
            this.IdCliente = idCliente;
            this.IdEmpleado = idEmpleado;
            this.Detalles = detalles;
        }
        /// <summary>
        /// Constructor para el INSERT VENTA
        /// </summary>
        /// <param name="fechaHoraVenta"></param>
        /// <param name="fechaHoraPedido"></param>
        /// <param name="montoTotal"></param>
        /// <param name="descuento"></param>
        /// <param name="estadoEntrega"></param>
        /// <param name="adelanto"></param>
        /// <param name="idCliente"></param>
        /// <param name="idEmpleado"></param>
        public Venta(double montoTotal, byte descuento, byte estadoEntrega, double adelanto, int idCliente, int idEmpleado, List<VentaDetalle> detalles)
        {
            this.MontoTotalVenta = montoTotal;
            this.Descuento = descuento;
            this.EstadoEntrega = estadoEntrega;
            this.Adelanto = adelanto;
            this.IdCliente = idCliente;
            this.IdEmpleado = idEmpleado;
            this.Detalles = detalles;
        }

        /// <summary>
        /// Constructor para el INSERT PEDIDO
        /// </summary>
        /// <param name="fechaHoraVenta"></param>
        /// <param name="fechaHoraPedido"></param>
        /// <param name="montoTotal"></param>
        /// <param name="descuento"></param>
        /// <param name="estadoEntrega"></param>
        /// <param name="adelanto"></param>
        /// <param name="idCliente"></param>
        /// <param name="idEmpleado"></param>
        public Venta(DateTime fechaHoraPedido, double montoTotal, byte descuento, byte estadoEntrega, double adelanto, int idCliente, int idEmpleado, List<VentaDetalle> detalles)
        {
            this.FechaHoraPedido = fechaHoraPedido;
            this.MontoTotalVenta = montoTotal;
            this.Descuento = descuento;
            this.EstadoEntrega = estadoEntrega;
            this.Adelanto = adelanto;
            this.IdCliente = idCliente;
            this.IdEmpleado = idEmpleado;
            this.Detalles = detalles;
        }

        #endregion
    }
}
