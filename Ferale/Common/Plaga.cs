using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de la clase PLAGA
    /// </summary>
    public class Plaga:Limpieza
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID de la plaga
        /// </summary>
        public int IdPlaga { get; set; }
        /// <summary>
        /// Descripcion de la plaga
        /// </summary>
        public string DescripcionPlaga { get; set; }
        /// <summary>
        /// Tratamiento de la plaga
        /// </summary>
        public string Tratamiento { get; set; }

        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Plaga()
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
        /// <param name="descripcionPlaga"></param>
        /// <param name="tratamiento"></param>
        public Plaga(int idLimpieza, DateTime fechaHora, byte idTipoLimpieza, byte idEstablecimiento, byte estado, int idPlaga, string descripcionPlaga, string tratamiento) :base(idLimpieza, fechaHora, idTipoLimpieza,idEstablecimiento,estado)
        {
            this.IdPlaga = idPlaga;
            this.DescripcionPlaga = descripcionPlaga;
            this.Tratamiento = tratamiento;
        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idLimpieza"></param>
        /// <param name="fechaHora"></param>
        /// <param name="idTipoLimpieza"></param>
        /// <param name="idEstablecimiento"></param>
        /// <param name="estado"></param>
        /// <param name="idPlaga"></param>
        /// <param name="descripcionPlaga"></param>
        /// <param name="tratamiento"></param>
        /// <param name="le"></param>
        public Plaga(int idLimpieza, DateTime fechaHora, byte idTipoLimpieza, byte idEstablecimiento, byte estado, int idPlaga, string descripcionPlaga, string tratamiento, LimpiezaEmpleado le) : base(idLimpieza, fechaHora, idTipoLimpieza, idEstablecimiento, estado, le)
        {
            this.IdPlaga = idPlaga;
            this.DescripcionPlaga = descripcionPlaga;
            this.Tratamiento = tratamiento;
        }
        /// <summary>
        /// Constructor para el INSERT
        /// </summary>
        /// <param name="fechaHora"></param>
        /// <param name="idTipoLimpieza"></param>
        /// <param name="idEstablecimiento"></param>
        /// <param name="descripcionPlaga"></param>
        /// <param name="tratamiento"></param>
        public Plaga(DateTime fechaHora, byte idTipoLimpieza, byte idEstablecimiento, string descripcionPlaga, string tratamiento, LimpiezaEmpleado le) : base(fechaHora, idTipoLimpieza, idEstablecimiento, le)
        {
            this.DescripcionPlaga = descripcionPlaga;
            this.Tratamiento = tratamiento;
        }

        #endregion
    }
}
