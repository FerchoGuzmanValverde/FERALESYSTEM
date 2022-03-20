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
    public sealed class TipoLimpiezaBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public TipoLimpieza TipoLimpieza { get; set; }
        public TipoLimpiezaDAL Dal { get; set; }

        public TipoLimpiezaBRL()
        {
            Dal = new TipoLimpiezaDAL();
        }

        public TipoLimpiezaBRL(TipoLimpieza Tipo)
        {
            this.TipoLimpieza = Tipo;
            Dal = new TipoLimpiezaDAL(this.TipoLimpieza);
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

        public TipoLimpieza Get(byte id)
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
