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
    public sealed class MesBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Mes Mes { get; set; }
        public MesDAL Dal { get; set; }

        public MesBRL()
        {
            Dal = new MesDAL();
        }

        public MesBRL(Mes Mes)
        {
            this.Mes = Mes;
            Dal = new MesDAL(this.Mes);
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

        public Mes Get(short id)
        {
            return Dal.Get(id);
        }

        public DataTable SelectByIdName()
        {
            return Dal.SelectByIdName();
        }

        #endregion
    }
}
