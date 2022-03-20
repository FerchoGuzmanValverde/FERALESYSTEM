using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public sealed class VentaDetalleBRL
    {
        #region Atributos y Constructores

        public VentaDetalle VentaDetalle { get; set; }
        public VentaDetalleDAL Dal { get; set; }

        public VentaDetalleBRL()
        {
            Dal = new VentaDetalleDAL();
        }

        public VentaDetalleBRL(VentaDetalle VentaDetalle)
        {
            this.VentaDetalle = VentaDetalle;
            Dal = new VentaDetalleDAL(this.VentaDetalle);
        }

        #endregion

        #region Metodos

        public List<VentaDetalle> listDetalles(int id)
        {
            return Dal.SelectDetails(id);
        }

        #endregion
    }
}
