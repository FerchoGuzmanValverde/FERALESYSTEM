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
    public sealed class ClienteDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Cliente Cliente { get; set; }

        public ClienteDAL()
        {

        }

        public ClienteDAL(Cliente Cliente)
        {
            this.Cliente = Cliente;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = "INSERT INTO Cliente (razonSocial, nit) VALUES (@razonSocial, @nit)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@razonSocial", Cliente.RazonSocial);
                cmd.Parameters.AddWithValue("@nit", Cliente.Nit);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);
                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Cliente");
                cmd.Parameters.AddWithValue("@crud", "C");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Methods.GetActIdTable("Cliente") + "Cliente insertado");
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
            string query = "UPDATE Cliente SET razonSocial=@razonSocial, nit=@nit WHERE idCliente=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Cliente.IdCliente);
                cmd.Parameters.AddWithValue("@razonSocial", Cliente.RazonSocial);
                cmd.Parameters.AddWithValue("@nit", Cliente.Nit);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Cliente");
                cmd.Parameters.AddWithValue("@crud", "U");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Cliente.IdCliente + " Cliente modificado");
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
            string query = "UPDATE Cliente SET estado=0 WHERE idCliente=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Cliente.IdCliente);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Cliente");
                cmd.Parameters.AddWithValue("@crud", "D");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Cliente.IdCliente + " Cliente Eliminado");
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
            string query = "SELECT * FROM vwCliente ORDER BY 2";
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

        public Cliente Get(int id)
        {
            Cliente cliente = null;

            string query = @"SELECT idCliente, razonSocial, nit, estado FROM Cliente WHERE idCliente = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    cliente = new Cliente(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), byte.Parse(dr[3].ToString()));
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

            return cliente;
        }

        public Cliente GetByNit(string nit)
        {
            Cliente cliente = null;

            string query = @"SELECT idCliente, razonSocial, nit, estado FROM Cliente WHERE nit = @nit";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nit", nit);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    cliente = new Cliente(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), byte.Parse(dr[3].ToString()));
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

            return cliente;
        }

        #endregion
    }
}
