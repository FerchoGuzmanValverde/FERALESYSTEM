using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class EmpleadoDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Empleado Empleado { get; set; }
        public UsuarioDAL DalUsuario { get; set; }

        public EmpleadoDAL()
        {
            this.DalUsuario = new UsuarioDAL();
        }

        public EmpleadoDAL(Empleado Empleado)
        {
            this.Empleado = Empleado;
            this.DalUsuario = new UsuarioDAL(Empleado.Usuario);
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = @"INSERT INTO Empleado (nombre, primerApellido, segundoApellido, cedulaIdentidad, fechaNacimiento, sexo, nroCuentaBancaria,
                                                   idAreaEmpresa, telefono, fotoPerfil, domicilio, idUsuario) 
                            VALUES (@nombre, @primerApellido, @segundoApellido, @cedulaIdentidad, @fechaNacimiento, @sexo, @nroCuentaBancaria,
                                    @idAreaEmpresa, @telefono, @fotoPerfil, @domicilio, @idUsuario)";
            SqlCommand cmd = null;

            DalUsuario.Insert();

            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@nombre", Empleado.Nombre);
                cmd.Parameters.AddWithValue("@primerApellido", Empleado.PrimerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", Empleado.SegundoApellido);
                cmd.Parameters.AddWithValue("@cedulaIdentidad", Empleado.CedulaIdentidad);
                cmd.Parameters.AddWithValue("@fechaNacimiento", Empleado.FechaNacimiento);
                cmd.Parameters.AddWithValue("@sexo", Empleado.Sexo);
                cmd.Parameters.AddWithValue("@nroCuentaBancaria", Empleado.NroCuentaBancaria);
                cmd.Parameters.AddWithValue("@idAreaEmpresa", Empleado.IdAreaEmpresa);
                cmd.Parameters.AddWithValue("@telefono", Empleado.Telefono);
                cmd.Parameters.AddWithValue("@fotoPerfil", Empleado.FotoPerfil);
                cmd.Parameters.AddWithValue("@domicilio", Empleado.Domicilio);
                cmd.Parameters.AddWithValue("@idUsuario", Methods.GetActIdTable("Usuario"));

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Empleado");
                cmd.Parameters.AddWithValue("@crud", "C");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Methods.GetActIdTable("Empleado") + " Empleado insertado");
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idUsuario);
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update()
        {
            string query = @"UPDATE Empleado SET nombre=@nombre, primerApellido=@primerApellido, segundoApellido=@segundoApellido, cedulaIdentidad=@cedulaIdentidad, 
                            fechaNacimiento=@fechaNacimiento, sexo=@sexo, nroCuentaBancaria=@nroCuentaBancaria, idAreaEmpresa=@idAreaEmpresa, telefono=@telefono,
                            fotoPerfil=@fotoPerfil, domicilio=@domicilio, idUsuario = @idUsuario
                            WHERE idEmpleado = @id";
            SqlCommand cmd = null;

            DalUsuario.Update();

            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Empleado.IdEmpleado);
                cmd.Parameters.AddWithValue("@nombre", Empleado.Nombre);
                cmd.Parameters.AddWithValue("@primerApellido", Empleado.PrimerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", Empleado.SegundoApellido);
                cmd.Parameters.AddWithValue("@cedulaIdentidad", Empleado.CedulaIdentidad);
                cmd.Parameters.AddWithValue("@fechaNacimiento", Empleado.FechaNacimiento);
                cmd.Parameters.AddWithValue("@sexo", Empleado.Sexo);
                cmd.Parameters.AddWithValue("@nroCuentaBancaria", Empleado.NroCuentaBancaria);
                cmd.Parameters.AddWithValue("@idAreaEmpresa", Empleado.IdAreaEmpresa);
                cmd.Parameters.AddWithValue("@telefono", Empleado.Telefono);
                cmd.Parameters.AddWithValue("@login", Empleado.Login);
                cmd.Parameters.AddWithValue("@password", Empleado.Password);
                cmd.Parameters.AddWithValue("@fotoPerfil", Empleado.FotoPerfil);
                cmd.Parameters.AddWithValue("@domicilio", Empleado.Domicilio);
                cmd.Parameters.AddWithValue("@idUsuario", Empleado.Usuario.IdUsuario);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Empleado");
                cmd.Parameters.AddWithValue("@crud", "U");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Empleado.IdEmpleado + " Empleado modificado");
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idUsuario);
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete()
        {
            string query = "UPDATE Empleado SET estado=0 WHERE idEmpleado=@id";
            SqlCommand cmd = null;

            DalUsuario.Delete();

            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Empleado.IdEmpleado);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Empleado");
                cmd.Parameters.AddWithValue("@crud", "D");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Empleado.IdEmpleado + " Empleado eliminado");
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idUsuario);
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override DataTable Select()
        {
            DataTable result = new DataTable();
            string query = "SELECT * FROM vwEmpleado";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                result = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public Empleado Get(int id)
        {
            Empleado empleado = null;

            string query = @"SELECT idEmpleado, nombre, primerApellido, segundoApellido, cedulaIdentidad, fechaNacimiento, sexo, nroCuentaBancaria,
                                    idAreaEmpresa, telefono, estado, fotoPerfil, domicilio, idUsuario FROM Empleado WHERE idEmpleado = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            Usuario user = DalUsuario.Get(id);

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    empleado = new Empleado(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), DateTime.Parse(dr[5].ToString()),
                                            byte.Parse(dr[6].ToString()), int.Parse(dr[7].ToString()), byte.Parse(dr[8].ToString()), dr[9].ToString(), byte.Parse(dr[10].ToString()),
                                            (byte[])dr[11], dr[12].ToString(), dr[13].ToString(), user);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }

            return empleado;
        }

        public Empleado GetByUser(int id)
        {
            Empleado empleado = null;

            string query = @"SELECT idEmpleado, nombre, primerApellido, segundoApellido, cedulaIdentidad, fechaNacimiento, sexo, nroCuentaBancaria,
                                    idAreaEmpresa, telefono, estado, fotoPerfil, domicilio, idUsuario FROM Empleado WHERE idUsuario = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            Usuario user = DalUsuario.Get(id);

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    empleado = new Empleado(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), DateTime.Parse(dr[5].ToString()),
                                            byte.Parse(dr[6].ToString()), int.Parse(dr[7].ToString()), byte.Parse(dr[8].ToString()), dr[9].ToString(), byte.Parse(dr[10].ToString()),
                                            (byte[])dr[11], dr[12].ToString(), dr[13].ToString(), user);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }

            return empleado;
        }

        public Empleado GetByName(string name)
        {
            Empleado empleado = null;

            string query = @"SELECT idEmpleado, nombre, primerApellido, segundoApellido, cedulaIdentidad, fechaNacimiento, sexo, nroCuentaBancaria,
                                    idAreaEmpresa, telefono, estado, fotoPerfil, domicilio, idUsuario FROM Empleado WHERE nombre LIKE @name OR primerApellido LIKE @name AND estado = 1";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@name", name);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                Usuario user = DalUsuario.Get(int.Parse(dr[0].ToString()));

                while (dr.Read())
                {
                    empleado = new Empleado(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), DateTime.Parse(dr[5].ToString()),
                                            byte.Parse(dr[6].ToString()), int.Parse(dr[7].ToString()), byte.Parse(dr[8].ToString()), dr[9].ToString(), byte.Parse(dr[10].ToString()),
                                            (byte[])dr[11], dr[12].ToString(), dr[13].ToString(), user);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                dr.Close();
            }

            return empleado;
        }

        public DataTable SelectIdName()
        {
            DataTable res = new DataTable();

            try
            {
                string query = "SELECT idEmpleado, CONCAT(nombre, ' ', primerApellido) AS 'empleado' FROM Empleado WHERE estado = 1";

                SqlCommand cmd = Methods.CreateBasicCommand(query);
                res = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return res;
        }

        #endregion
    }
}
