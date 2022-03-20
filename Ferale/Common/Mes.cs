using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de MES
    /// </summary>
    public class Mes
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID del mes
        /// </summary>
        public short IdMes { get; set; }
        /// <summary>
        /// Nombre del mes
        /// </summary>
        public string NombreMes { get; set; }
        /// <summary>
        /// Año al que pertenece el mes
        /// </summary>
        public short Anio { get; set; }
        /// <summary>
        /// Estado del mes
        /// </summary>
        public byte Estado { get; set; }

        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Mes()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idMes"></param>
        /// <param name="nombreMes"></param>
        /// <param name="anio"></param>
        /// <param name="estado"></param>
        public Mes(short idMes, string nombreMes, short anio, byte estado)
        {
            this.IdMes = idMes;
            this.NombreMes = nombreMes;
            this.Anio = anio;
            this.Estado = estado;
        }
        /// <summary>
        /// Constructor para el INSERT
        /// </summary>
        /// <param name="nombreMes"></param>
        /// <param name="anio"></param>
        public Mes(string nombreMes, short anio)
        {
            this.NombreMes = nombreMes;
            this.Anio = anio;
        }

        #endregion
    }
}
