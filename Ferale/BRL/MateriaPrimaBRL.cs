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
    public sealed class MateriaPrimaBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public MateriaPrima Materia { get; set; }
        public MateriaPrimaDAL Dal { get; set; }

        public MateriaPrimaBRL()
        {
            Dal = new MateriaPrimaDAL();
        }

        public MateriaPrimaBRL(MateriaPrima Materia)
        {
            this.Materia = Materia;
            Dal = new MateriaPrimaDAL(this.Materia);
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

        public MateriaPrima Get(short id)
        {
            return Dal.Get(id);
        }

        public DataTable SelectByIdName(short idProveedor)
        {
            return Dal.SelectByIdName(idProveedor);
        }

        public DataTable SelectIdName()
        {
            return Dal.SelectIdName();
        }
    #endregion
}
}
