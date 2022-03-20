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
    public sealed class AlmacenBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Almacen Almacen { get; set; }
        public AlmacenDAL Dal { get; set; }

        public AlmacenBRL()
        {
            Dal = new AlmacenDAL();
        }

        public AlmacenBRL(Almacen Almacen)
        {
            this.Almacen = Almacen;
            Dal = new AlmacenDAL(this.Almacen);
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

        public Almacen Get(byte id)
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
