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
    public sealed class ProductoBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Producto Producto { get; set; }
        public ProductoDAL Dal { get; set; }

        public ProductoBRL()
        {
            Dal = new ProductoDAL();
        }

        public ProductoBRL(Producto Producto)
        {
            this.Producto = Producto;
            Dal = new ProductoDAL(this.Producto);
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

        public Producto Get(short id)
        {
            return Dal.Get(id);
        }

        public DataTable SelectByIdName(byte tipo)
        {
            return Dal.SelectByIdName(tipo);
        }

        #endregion
    }
}
