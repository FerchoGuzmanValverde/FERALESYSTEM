using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MateriaProduccion
    {
        #region Atributos y Propiedades
        /// <summary>
        /// IdMateria
        /// </summary>
        public short IdMateria { get; set; }
        /// <summary>
        /// Id de la Produccion
        /// </summary>
        public int IdProduccion { get; set; }
        /// <summary>
        /// Cantidad de Materia Utilizada
        /// </summary>
        public double Cantidad { get; set; }
        public byte Estado { get; set; }
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public MateriaProduccion()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idMateria"></param>
        /// <param name="idProduccion"></param>
        /// <param name="cantidad"></param>
        /// <param name="estado"></param>
        public MateriaProduccion(short idMateria, int idProduccion, double cantidad, byte estado)
        {
            this.IdMateria = idMateria;
            this.IdProduccion = idProduccion;
            this.Cantidad = cantidad;
            this.Estado = estado;
        }

        /// <summary>
        /// Cosntructor para el insert
        /// </summary>
        /// <param name="idMateria"></param>
        /// <param name="idProduccion"></param>
        /// <param name="cantidad"></param>
        public MateriaProduccion(short idMateria, int idProduccion, double cantidad)
        {
            this.IdMateria = idMateria;
            this.IdProduccion = idProduccion;
            this.Cantidad = cantidad;
        }
        #endregion
    }
}
