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
    public sealed class UsuarioBRL : OperacionesAbstractBRL
    {
        public UsuarioDAL Dal { get; set; }

        public UsuarioBRL()
        {
            Dal = new UsuarioDAL();
        }

        public UsuarioBRL(Usuario user)
        {
            Dal = new UsuarioDAL(user);
        }

        public override void Delete()
        {
            Dal.Delete();
        }

        public override void Insert()
        {
            Dal.Insert();
        }

        public override DataTable Select()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            Dal.Update();
        }

        public Usuario GetByCode(string code)
        {
            return Dal.GetByCode(code);
        }

        public List<string> GetByEmail(string email)
        {
            return Dal.GetByEmail(email);
        }

        public Usuario GetUserByEmail(string email)
        {
            return Dal.GetUserByEmail(email);
        }

        public DataTable Login(string nombreUsuario, string password)
        {
            return Dal.Login(nombreUsuario, password);
        }

        public void CrearEmail()
        {
            Dal.CrearMail();
        }
    }
}
