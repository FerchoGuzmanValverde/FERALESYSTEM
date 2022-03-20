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
    public sealed class EstablecimientoBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Establecimiento Establecimiento { get; set; }
        public EstablecimientoDAL Dal { get; set; }

        public EstablecimientoBRL()
        {
            Dal = new EstablecimientoDAL();
        }

        public EstablecimientoBRL(Establecimiento Est)
        {
            this.Establecimiento = Est;
            Dal = new EstablecimientoDAL(this.Establecimiento);
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

        public Establecimiento Get(byte id)
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
