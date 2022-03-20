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
    public sealed class TipoProductoBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public TipoProducto TipoProducto { get; set; }
        public TipoProductoDAL Dal { get; set; }

        public TipoProductoBRL()
        {
            Dal = new TipoProductoDAL();
        }

        public TipoProductoBRL(TipoProducto Tipo)
        {
            this.TipoProducto = Tipo;
            Dal = new TipoProductoDAL(this.TipoProducto);
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

        public TipoProducto Get(byte id)
        {
            return Dal.Get(id);
        }

        public DataTable SelectIdName()
        {
            return Dal.SelectIdName();
        }

        #endregion
    }
}
