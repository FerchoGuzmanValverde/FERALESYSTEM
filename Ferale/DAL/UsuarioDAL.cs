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
    public sealed class UsuarioDAL : OperacionesAbstractDAL
    {
        Usuario user;
        MailDAL DalMail;
        Mail email;

        public UsuarioDAL()
        {

        }

        public UsuarioDAL(Usuario user)
        {
            this.user = user;
        }

        public override void Delete()
        {
            string query = "UPDATE Usuario SET estado=0 WHERE idUsuario=@id";
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", user.IdUsuario);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Usuario");
                cmd.Parameters.AddWithValue("@crud", "D");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" +user.IdUsuario+ "Usuario eliminado");
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idUsuario);
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Insert()
        {
            string query = "INSERT INTO Usuario (rol, nombreUsuario, passwordUsuario, settings, correo, codigo) VALUES (@rol, @nombre, HASHBYTES('md5',@password), @settings, @correo, @codigo)";
            SqlCommand cmd = null;

            CrearMail();

            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@rol", user.Rol);
                cmd.Parameters.AddWithValue("@nombre", user.NombreUsuario);
                cmd.Parameters.AddWithValue("@password", user.PasswordUsuario);
                cmd.Parameters.AddWithValue("@settings", user.Settings);
                cmd.Parameters.AddWithValue("@correo", user.Correo);
                cmd.Parameters.AddWithValue("@codigo", user.Codigo);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Usuario");
                cmd.Parameters.AddWithValue("@crud", "C");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Methods.GetActIdTable("Usuario") + " Usuario insertado");
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
            throw new NotImplementedException();
        }

        public override void Update()
        {
            string query = @"UPDATE Usuario 
                            SET rol = @rol, nombreUsuario = @nombre, passwordUsuario = HASHBYTES('md5',@password), settings = @settings, correo = @correo, codigo = @codigo
                            WHERE idUsuario=@id";
            SqlCommand cmd = null;

            //PONER ESTO EN EL RECOVER
            /*CrearMail();
            DalMail = new MailDAL(email);
            DalMail.sendMail();*/

            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", user.IdUsuario);
                cmd.Parameters.AddWithValue("@rol", user.Rol);
                cmd.Parameters.AddWithValue("@nombre", user.NombreUsuario);
                cmd.Parameters.AddWithValue("@password", user.PasswordUsuario).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@settings", user.Settings);
                cmd.Parameters.AddWithValue("@correo", user.Correo);
                cmd.Parameters.AddWithValue("@codigo", user.Codigo);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Usuario");
                cmd.Parameters.AddWithValue("@crud", "U");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + user.IdUsuario + "Usuario modificado");
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idUsuario);
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Get(int id)
        {
            Usuario user = null;

            string query = @"SELECT idUsuario, rol, nombreUsuario, passwordUsuario, settings, correo, codigo, estado FROM Usuario WHERE idUsuario = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    user = new Usuario(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), byte.Parse(dr[4].ToString()), dr[5].ToString(), dr[6].ToString(), byte.Parse(dr[7].ToString()));
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

            return user;
        }

        public Usuario GetByCode(string code)
        {
            Usuario user = null;

            string query = @"SELECT idUsuario, rol, nombreUsuario, passwordUsuario, settings, correo, codigo, estado FROM Usuario WHERE codigo = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", code);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    user = new Usuario(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), byte.Parse(dr[4].ToString()), dr[5].ToString(), dr[6].ToString(), byte.Parse(dr[7].ToString()));
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

            return user;
        }

        public List<string> GetByEmail(string email)
        {
            List<string> datos = new List<string>();

            string query = @"SELECT E.nombre, E.cedulaIdentidad
                                FROM Empleado E
                                INNER JOIN Usuario U ON E.idUsuario = U.idUsuario
                                WHERE U.correo = @email";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@email", email);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    datos.Add(dr[0].ToString());
                    datos.Add(dr[1].ToString());
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

            return datos;
        }

        public Usuario GetUserByEmail(string email)
        {
            Usuario user = null;

            string query = @"SELECT idUsuario, rol, nombreUsuario, passwordUsuario, settings, correo, codigo, estado
                                FROM Usuario
                                WHERE correo = @email";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@email", email);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    user = new Usuario(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), byte.Parse(dr[4].ToString()), dr[5].ToString(), dr[6].ToString(), byte.Parse(dr[7].ToString()));
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

            return user;
        }

        public DataTable Login(string nombreUsuario, string password)
        {
            DataTable result = new DataTable();
            string query = @"SELECT idUsuario, nombreUsuario, rol, settings
                            FROM Usuario WHERE estado = 1 AND @nombreUsuario = nombreUsuario AND passwordUsuario = HASHBYTES('md5',@password)";

            try
            {
                SqlCommand cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
                result = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void CrearMail()
        {
            string Subject = "Codigo de Acceso Sistema de Información Ferale!!";
            string Body = "Utilice el siguiente código de ingreso: " + user.Codigo;
            string RecipientEmail = user.Correo;

            email = new Mail(Subject, Body, RecipientEmail);

            DalMail = new MailDAL(email);
            DalMail.sendMail();
        }
    }
}
