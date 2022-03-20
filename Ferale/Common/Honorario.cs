using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de HONORARIO
    /// </summary>
    public class Honorario
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID del honorario
        /// </summary>
        public int IdHonorario { get; set; }
        /// <summary>
        /// Fecha de pago del honorario
        /// </summary>
        public DateTime FechaCancelado { get; set; }
        /// <summary>
        /// Monto total cancelado del honorario
        /// </summary>
        public double MontoTotalCancelado { get; set; }
        /// <summary>
        /// Dia completo de trabajo
        /// </summary>
        public byte DiaCompletoTrabajo { get; set; }
        /// <summary>
        /// Medio dia de trabajo
        /// </summary>
        public byte MedioDiaTrabajo { get; set; }
        /// <summary>
        /// Pago medio día
        /// </summary>
        public double PagoMedioDia { get; set; }
        /// <summary>
        /// Dia final pagado
        /// </summary>
        public DateTime DiaFinalPagado { get; set; }
        /// <summary>
        /// ID del empleado
        /// </summary>
        public int IdEmpleado { get; set; }
        /// <summary>
        /// ID del mes
        /// </summary>
        public short IdMes { get; set; }
        /// <summary>
        /// Estado del honorario
        /// </summary>
        public byte Estado { get; set; }

        #endregion
        #region Constructores
        /// <summary>
        /// Contructor por defecto
        /// </summary>
        public Honorario()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idHonorario"></param>
        /// <param name="fechaCancelado"></param>
        /// <param name="montoTotalAbonado"></param>
        /// <param name="diaCompleto"></param>
        /// <param name="medioDia"></param>
        /// <param name="pagoMedioDia"></param>
        /// <param name="ultimoDiaPagado"></param>
        /// <param name="idEmpleado"></param>
        /// <param name="idMes"></param>
        /// <param name="estado"></param>
        public Honorario(int idHonorario, DateTime fechaCancelado, double montoTotalAbonado, byte diaCompleto, byte medioDia, double pagoMedioDia, DateTime ultimoDiaPagado, int idEmpleado, short idMes, byte estado)
        {
            this.IdHonorario = idHonorario;
            this.FechaCancelado = fechaCancelado;
            this.MontoTotalCancelado = montoTotalAbonado;
            this.DiaCompletoTrabajo = diaCompleto;
            this.MedioDiaTrabajo = medioDia;
            this.PagoMedioDia = pagoMedioDia;
            this.DiaFinalPagado = ultimoDiaPagado;
            this.IdEmpleado = idEmpleado;
            this.IdMes = idMes;
            this.Estado = estado;
        }
        /// <summary>
        /// Constructor para el INSERT
        /// </summary>
        /// <param name="montoTotalAbonado"></param>
        /// <param name="diaCompleto"></param>
        /// <param name="medioDia"></param>
        /// <param name="pagoMedioDia"></param>
        /// <param name="ultimoDiaPagado"></param>
        /// <param name="idEmpleado"></param>
        /// <param name="idMes"></param>
        public Honorario(double montoTotalAbonado, byte diaCompleto, byte medioDia, double pagoMedioDia, DateTime ultimoDiaPagado, int idEmpleado, short idMes)
        {
            this.MontoTotalCancelado = montoTotalAbonado;
            this.DiaCompletoTrabajo = diaCompleto;
            this.MedioDiaTrabajo = medioDia;
            this.PagoMedioDia = pagoMedioDia;
            this.DiaFinalPagado = ultimoDiaPagado;
            this.IdEmpleado = idEmpleado;
            this.IdMes = idMes;
        }

        #endregion
    }
}
