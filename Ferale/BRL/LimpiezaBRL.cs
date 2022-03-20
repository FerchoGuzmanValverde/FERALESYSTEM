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
    public sealed class LimpiezaBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Limpieza Limpieza { get; set; }
        public LimpiezaDAL Dal { get; set; }

        public LimpiezaBRL()
        {
            Dal = new LimpiezaDAL();
        }

        public LimpiezaBRL(Limpieza Limpieza)
        {
            this.Limpieza = Limpieza;
            Dal = new LimpiezaDAL(this.Limpieza);
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

        public Limpieza Get(int id)
        {
            return Dal.Get(id);
        }

        #endregion
    }
}
