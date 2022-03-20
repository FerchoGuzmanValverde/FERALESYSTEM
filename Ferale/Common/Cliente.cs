using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de Cliente
    /// </summary>
    public class Cliente
    {
        #region Atributos y Propiedades de la clase
        /// <summary>
        /// ID del cliente
        /// </summary>
        public int IdCliente { get; set; }
        /// <summary>
        /// Razon social del cliente
        /// </summary>
        public string RazonSocial { get; set; }
        /// <summary>
        /// Nit del cliente
        /// </summary>
        public string Nit { get; set; }
        /// <summary>
        /// Estado del cliente
        /// </summary>
        public byte Estado { get; set; }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de cliente por defecto
        /// </summary>
        public Cliente()
        {

        }
        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="razonSocial"></param>
        /// <param name="nit"></param>
        /// <param name="estado"></param>
        public Cliente(int idCliente, string razonSocial, string nit, byte estado)
        {
            IdCliente = idCliente;
            RazonSocial = razonSocial;
            Nit = nit;
            Estado = estado;
        }
        /// <summary>
        /// Constructor para el INSERT
        /// </summary>
        /// <param name="razonSocial"></param>
        /// <param name="nit"></param>
        public Cliente(string razonSocial, string nit)
        {
            this.RazonSocial = razonSocial;
            this.Nit = nit;
        }

        #endregion
    }
}
