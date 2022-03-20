using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de GASTO
    /// </summary>
    public class Gasto
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID del gasto
        /// </summary>
        public short IdGasto { get; set; }
        /// <summary>
        /// Precio unitario del gasto
        /// </summary>
        public double PrecioUnitario { get; set; }
        /// <summary>
        /// Fecha de pago del gasto
        /// </summary>
        public DateTime FechaCancelado { get; set; }
        /// <summary>
        /// Cantidad del gasto
        /// </summary>
        public double Cantidad { get; set; }
        /// <summary>
        /// ID del empleado
        /// </summary>
        public int IdEmpleado { get; set; }
        /// <summary>
        /// ID del servicio
        /// </summary>
        public short IdServicio { get; set; }
        /// <summary>
        /// Estado del gasto
        /// </summary>
        public byte Estado { get; set; }

        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Gasto()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idGasto"></param>
        /// <param name="precioUnitario"></param>
        /// <param name="fechaCancelado"></param>
        /// <param name="cantidad"></param>
        /// <param name="idEmpleado"></param>
        /// <param name="idServicio"></param>
        /// <param name="estado"></param>
        public Gasto(short idGasto, double precioUnitario, DateTime fechaCancelado, double cantidad, int idEmpleado, short idServicio, byte estado)
        {
            this.IdGasto = idGasto;
            this.PrecioUnitario = precioUnitario;
            this.FechaCancelado = fechaCancelado;
            this.Cantidad = cantidad;
            this.IdEmpleado = idEmpleado;
            this.IdServicio = idServicio;
            this.Estado = estado;
        }
        /// <summary>
        /// Constructor para el INSERT
        /// </summary>
        /// <param name="precioUnitario"></param>
        /// <param name="fechaCancelado"></param>
        /// <param name="cantidad"></param>
        /// <param name="idEmpleado"></param>
        /// <param name="idServicio"></param>
        public Gasto(double precioUnitario, DateTime fechaCancelado, double cantidad, int idEmpleado, short idServicio)
        {
            this.PrecioUnitario = precioUnitario;
            this.FechaCancelado = fechaCancelado;
            this.Cantidad = cantidad;
            this.IdEmpleado = idEmpleado;
            this.IdServicio = idServicio;
        }

        #endregion
    }
}
