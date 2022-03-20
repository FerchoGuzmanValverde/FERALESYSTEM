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
    public sealed class ServicioBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Servicio Servicio { get; set; }
        public ServicioDAL Dal { get; set; }

        public ServicioBRL()
        {
            Dal = new ServicioDAL();
        }

        public ServicioBRL(Servicio Servicio)
        {
            this.Servicio = Servicio;
            Dal = new ServicioDAL(this.Servicio);
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

        public Servicio Get(short id)
        {
            return Dal.Get(id);
        }

        #endregion
    }
}
