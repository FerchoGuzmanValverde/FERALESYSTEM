using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de Proveedor
    /// </summary>
    public class Proveedor
    {
        #region Atributos y Propiedades de la clase
        /// <summary>
        /// ID del proveedor
        /// </summary>
        public short IdProveedor { get; set; }
        /// <summary>
        /// Razon social del proveedor
        /// </summary>
        public string RazonSocial { get; set; }
        /// <summary>
        /// Nit del proveedor
        /// </summary>
        public string Nit { get; set; }
        /// <summary>
        /// Telefono del proveedor
        /// </summary>
        public string Telefono { get; set; }
        /// <summary>
        /// Nro de cuenta bancaria del proveedor
        /// </summary>
        public int NroCuentaBancaria { get; set; }
        /// <summary>
        /// Estado del proveedor
        /// </summary>
        public byte Estado { get; set; }

        #endregion

        #region Constructores de la clase

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Proveedor()
        {

        }

        /// <summary>
        /// Constructor para el GET
        /// </summary>
        /// <param name="IdProveedor"></param>
        /// <param name="RazonSocial"></param>
        /// <param name="Nit"></param>
        /// <param name="Telefono"></param>
        /// <param name="NroCuentaBancaria"></param>
        /// <param name="Estado"></param>
        public Proveedor(short IdProveedor, string RazonSocial, string Nit, string Telefono, int NroCuentaBancaria, byte Estado)
        {
            this.IdProveedor = IdProveedor;
            this.RazonSocial = RazonSocial;
            this.Nit = Nit;
            this.Telefono = Telefono;
            this.NroCuentaBancaria = NroCuentaBancaria;
            this.Estado = Estado;
        }

        /// <summary>
        /// Constructor para el Insert
        /// </summary>
        /// <param name="RazonSocial"></param>
        /// <param name="Nit"></param>
        /// <param name="Telefono"></param>
        /// <param name="NroCuentaBancaria"></param>
        public Proveedor(string RazonSocial, string Nit, string Telefono, int NroCuentaBancaria)
        {
            this.RazonSocial = RazonSocial;
            this.Nit = Nit;
            this.Telefono = Telefono;
            this.NroCuentaBancaria = NroCuentaBancaria;
        }

        #endregion
    }
}
