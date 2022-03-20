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
    public sealed class EmpleadoBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Empleado Empleado { get; set; }
        public EmpleadoDAL Dal { get; set; }

        public EmpleadoBRL()
        {
            Dal = new EmpleadoDAL();
        }

        public EmpleadoBRL(Empleado Empleado)
        {
            this.Empleado = Empleado;
            Dal = new EmpleadoDAL(this.Empleado);
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

        public Empleado Get(int id)
        {
            return Dal.Get(id);
        }

        public Empleado GetByUser(int id)
        {
            return Dal.GetByUser(id);
        }

        public Empleado GetByName(string name)
        {
            return Dal.GetByName(name);
        }

        public DataTable SelectIdName()
        {
            return Dal.SelectIdName();
        }

        #endregion
    }
}
