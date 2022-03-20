using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;

namespace BRL
{
    public sealed class AreaEmpresaBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public AreaEmpresa Area { get; set; }
        public AreaEmpresaDAL Dal { get; set; }

        public AreaEmpresaBRL()
        {
            Dal = new AreaEmpresaDAL();
        }

        public AreaEmpresaBRL(AreaEmpresa Area)
        {
            this.Area = Area;
            Dal = new AreaEmpresaDAL(this.Area);
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

        public AreaEmpresa Get(byte id)
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
