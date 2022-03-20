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
    public sealed class ProveedorBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Proveedor Proveedor { get; set; }
        public ProveedorDAL Dal { get; set; }

        public ProveedorBRL()
        {
            Dal = new ProveedorDAL();
        }

        public ProveedorBRL(Proveedor Proveedor)
        {
            this.Proveedor = Proveedor;
            Dal = new ProveedorDAL(this.Proveedor);
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

        public Proveedor Get(short id)
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
