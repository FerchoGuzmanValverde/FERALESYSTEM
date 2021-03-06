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
    public sealed class ClienteBRL : OperacionesAbstractBRL
    {
        #region Atributos y Constructores

        public Cliente Cliente { get; set; }
        public ClienteDAL Dal { get; set; }

        public ClienteBRL()
        {
            Dal = new ClienteDAL();
        }

        public ClienteBRL(Cliente Cliente)
        {
            this.Cliente = Cliente;
            Dal = new ClienteDAL(this.Cliente);
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

        public Cliente Get(int id)
        {
            return Dal.Get(id);
        }

        public Cliente GetByNit(string nit)
        {
            return Dal.GetByNit(nit);
        }

        #endregion
    }
}
