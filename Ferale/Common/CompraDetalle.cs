using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase para crear objetos de COMPRADETALLE
    /// </summary>
    public class CompraDetalle
    {
        #region Atributos y Propiedades
        /// <summary>
        /// ID del detalle de la compra
        /// </summary>
        public int IdCompra { get; set; }
        /// <summary>
        /// ID de la materia prima
        /// </summary>
        public short IdMateria { get; set; }
        /// <summary>
        /// Cantidad dela materia prima
        /// </summary>
        public double Cantidad { get; set; }
        /// <summary>
        /// Precio unitario de compra de la materia prima
        /// </summary>
        public double PrecioUnitario { get; set; }

        #endregion

        #region Constructores
        /// <summary>
        /// Contrustor por defecto del detalle de la compra
        /// </summary>
        public CompraDetalle()
        {

        }
        /// <summary>
        /// Constructor para el GET y el INSERT
        /// </summary>
        /// <param name="idCompra"></param>
        /// <param name="idMateria"></param>
        /// <param name="cantidad"></param>
        /// <param name="precioUnitario"></param>
        public CompraDetalle(int idCompra, short idMateria, double cantidad, double precioUnitario)
        {
            this.IdCompra = idCompra;
            this.IdMateria = idMateria;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
        }

        #endregion
    }
}
