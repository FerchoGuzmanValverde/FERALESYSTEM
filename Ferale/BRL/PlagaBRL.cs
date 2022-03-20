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
    public sealed class PlagaBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Plaga Plaga { get; set; }
        public PlagaDAL Dal { get; set; }

        public PlagaBRL()
        {
            Dal = new PlagaDAL();
        }

        public PlagaBRL(Plaga Plaga)
        {
            this.Plaga = Plaga;
            Dal = new PlagaDAL(this.Plaga);
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

        public Plaga Get(int id)
        {
            return Dal.Get(id);
        }

        #endregion
    }
}
