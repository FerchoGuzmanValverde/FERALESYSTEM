using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LimpiezaEmpleado
    {
        #region Atributos y Propiedades
        /// <summary>
        /// Id de la Limpieza
        /// </summary>
        public int IdLimpieza { get; set; }
        /// <summary>
        /// Id del empleado
        /// </summary>
        public int IdEmpleado { get; set; }
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public LimpiezaEmpleado()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idLimpieza"></param>
        /// <param name="idEmpleado"></param>
        public LimpiezaEmpleado(int idLimpieza, int idEmpleado)
        {
            this.IdEmpleado = idEmpleado;
            this.IdLimpieza = idLimpieza;
        }
        /// <summary>
        /// Constructor para el INSERT
        /// </summary>
        /// <param name="idEmpleado"></param>
        public LimpiezaEmpleado(int idEmpleado)
        {
            this.IdEmpleado = idEmpleado;
        }
        #endregion
    }
}
