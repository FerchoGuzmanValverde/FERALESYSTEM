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
    public sealed class CompraBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Compra compra { get; set; }
        public CompraDAL Dal { get; set; }

        public CompraBRL()
        {
            Dal = new CompraDAL();
        }

        public CompraBRL(Compra Compra)
        {
            this.compra = Compra;
            Dal = new CompraDAL(this.compra);
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

        public Compra Get(int id)
        {
            return Dal.Get(id);
        }

        #endregion
    }
}
