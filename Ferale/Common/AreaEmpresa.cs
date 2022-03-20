using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de AreaEmpresa
    /// </summary>
    public class AreaEmpresa
    {
        #region Atributos y Propiedades de la clase

        /// <summary>
        /// ID del area empresa
        /// </summary>
        public byte IdAreaEmpresa { get; set; }
        /// <summary>
        /// Nombre del Area empresa
        /// </summary>
        //AreaEmpresa esta como NombreAreaEmpresa ya que tiene el mismo nombre que la clase
        public string NombreAreaEmpresa { get; set; }
        /// <summary>
        /// Esatdo del area empresa
        /// </summary>
        public byte Estado { get; set; }

        #endregion

        #region Constructores de la clase

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public AreaEmpresa()
        {

        }

        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="IdAreaEmpresa"></param>
        /// <param name="NombreAreaEmpresa"></param>
        public AreaEmpresa(byte IdAreaEmpresa, string NombreAreaEmpresa, byte Estado)
        {
            this.IdAreaEmpresa = IdAreaEmpresa;
            this.NombreAreaEmpresa = NombreAreaEmpresa;
            this.Estado = Estado;
        }

        /// <summary>
        /// Constructor para el INSERTAR
        /// </summary>
        /// <param name="NombreAreaEmpresa"></param>
        public AreaEmpresa(string NombreAreaEmpresa)
        {
            this.NombreAreaEmpresa = NombreAreaEmpresa;
        }

        #endregion
    }
}
