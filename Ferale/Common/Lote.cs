using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de LOTE
    /// </summary>
    public class Lote
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID del nro de lote
        /// </summary>
        public int IdLote { get; set; }
        /// <summary>
        /// Nro de lote
        /// </summary>
        public string NroLote { get; set; }
        /// <summary>
        /// Estado del nro de lote
        /// </summary>
        public byte Estado { get; set; }

        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Lote()
        {
            
        }
        /// <summary>
        /// Clase para el GET
        /// </summary>
        /// <param name="idLote"></param>
        /// <param name="nroLote"></param>
        /// <param name="estado"></param>
        public Lote(int idLote, string nroLote, byte estado)
        {
            this.IdLote = idLote;
            this.NroLote = nroLote;
            this.Estado = estado;
        }
        /// <summary>
        /// Constructor para el INSERT
        /// </summary>
        /// <param name="nroLote"></param>
        public Lote(string nroLote)
        {
            this.NroLote = nroLote;
        }

        #endregion
    }
}
