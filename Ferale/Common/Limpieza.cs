using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de la clase Limpieza
    /// </summary>
    public class Limpieza
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID de la limpieza
        /// </summary>
        public int IdLimpieza { get; set; }
        /// <summary>
        /// Fecha hora de la limpieza
        /// </summary>
        public DateTime FechaHoraLimpieza { get; set; }
        /// <summary>
        /// ID del tipo de limpieza
        /// </summary>
        public byte IdTipoLimpieza { get; set; }
        /// <summary>
        /// ID del establecimiento
        /// </summary>
        public byte IdEstablecimiento { get; set; }
        /// <summary>
        /// Estado de la limpieza
        /// </summary>
        public byte Estado { get; set; }
        /// <summary>
        /// Empleado responsable de la limpieza
        /// </summary>
        public LimpiezaEmpleado EmpleadoEncargado { get; set; }

        #endregion
        #region Constructores
        /// <summary>
        /// Contructor por defecto
        /// </summary>
        public Limpieza()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idLimpieza"></param>
        /// <param name="fechaHora"></param>
        /// <param name="idTipoLimpieza"></param>
        /// <param name="idEstablecimiento"></param>
        /// <param name="estado"></param>
        public Limpieza(int idLimpieza, DateTime fechaHora, byte idTipoLimpieza, byte idEstablecimiento, byte estado)
        {
            this.IdLimpieza = idLimpieza;
            this.FechaHoraLimpieza = fechaHora;
            this.IdTipoLimpieza = idTipoLimpieza;
            this.IdEstablecimiento = idEstablecimiento;
            this.Estado = estado;
        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idLimpieza"></param>
        /// <param name="fechaHora"></param>
        /// <param name="idTipoLimpieza"></param>
        /// <param name="idEstablecimiento"></param>
        /// <param name="estado"></param>
        /// <param name="le"></param>
        public Limpieza(int idLimpieza, DateTime fechaHora, byte idTipoLimpieza, byte idEstablecimiento, byte estado, LimpiezaEmpleado le)
        {
            this.IdLimpieza = idLimpieza;
            this.FechaHoraLimpieza = fechaHora;
            this.IdTipoLimpieza = idTipoLimpieza;
            this.IdEstablecimiento = idEstablecimiento;
            this.Estado = estado;
            this.EmpleadoEncargado = le;
        }
        /// <summary>
        /// Constructor para el INSERT
        /// </summary>
        /// <param name="fechaHora"></param>
        /// <param name="idTipoLimpieza"></param>
        /// <param name="idEstablecimiento"></param>
        /// <param name="empleado"></param>
        public Limpieza(DateTime fechaHora, byte idTipoLimpieza, byte idEstablecimiento, LimpiezaEmpleado empleado)
        {
            this.FechaHoraLimpieza = fechaHora;
            this.IdTipoLimpieza = idTipoLimpieza;
            this.IdEstablecimiento = idEstablecimiento;
            this.EmpleadoEncargado = empleado;
        }

        #endregion
    }
}
