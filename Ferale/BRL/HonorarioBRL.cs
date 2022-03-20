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
    public sealed class HonorarioBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Honorario Sueldo { get; set; }
        public HonorarioDAL Dal { get; set; }

        public HonorarioBRL()
        {
            Dal = new HonorarioDAL();
        }

        public HonorarioBRL(Honorario sueldo)
        {
            this.Sueldo = sueldo;
            Dal = new HonorarioDAL(this.Sueldo);
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

        public Honorario Get(int id)
        {
            return Dal.Get(id);
        }

        #endregion
    }
}
