using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;
using System.Data;

namespace BRL
{
    public sealed class ProduccionBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Produccion Produccion { get; set; }
        public ProduccionDAL Dal { get; set; }

        public ProduccionBRL()
        {
            Dal = new ProduccionDAL();
        }

        public ProduccionBRL(Produccion Produccion)
        {
            this.Produccion = Produccion;
            Dal = new ProduccionDAL(this.Produccion);
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

        public Produccion Get(int idProduccion)
        {
            return Dal.Get(idProduccion);
        }

        #endregion
    }
}
