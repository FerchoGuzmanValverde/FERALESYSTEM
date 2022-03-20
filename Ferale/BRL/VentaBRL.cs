using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    public sealed class VentaBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Venta Venta { get; set; }
        public VentaDAL Dal { get; set; }

        public VentaBRL()
        {
            Dal = new VentaDAL();
        }

        public VentaBRL(Venta Venta)
        {
            this.Venta = Venta;
            Dal = new VentaDAL(this.Venta);
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            Dal.Insert();
        }

        public override void Update()
        {
            Dal.Update();
        }

        public override void Delete()
        {
            Dal.Delete();
        }

        public override DataTable Select()
        {
            return Dal.Select();
        }

        public Venta Get(int id)
        {
            return Dal.Get(id);
        }

        #endregion
    }
}
