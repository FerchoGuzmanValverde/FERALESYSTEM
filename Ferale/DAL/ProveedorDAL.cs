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
    public sealed class ProveedorDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Proveedor Proveedor { get; set; }

        public ProveedorDAL()
        {

        }

        public ProveedorDAL(Proveedor Proveedor)
        {
            this.Proveedor = Proveedor;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = @"INSERT INTO Proveedor (razonSocial, nitProveedor, telefono, nroCuentaBancaria) 
                            VALUES (@razonSocial, @nitProveedor, @telefono, @nroCuentaBancaria)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@razonSocial", Proveedor.RazonSocial);
                cmd.Parameters.AddWithValue("@nitProveedor", Proveedor.Nit);
                cmd.Parameters.AddWithValue("@telefono", Proveedor.Telefono);
                cmd.Parameters.AddWithValue("@nroCuentaBancaria", Proveedor.NroCuentaBancaria);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Proveedor");
                cmd.Parameters.AddWithValue("@crud", "C");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Methods.GetActIdTable("Proveedor") + " Proveedor insertado");
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
            string query = "UPDATE Proveedor SET razonSocial=@razonSocial, nitProveedor=@nit, telefono=@telefono, nroCuentaBancaria=@nroCuenta WHERE idProveedor=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Proveedor.IdProveedor);
                cmd.Parameters.AddWithValue("@razonSocial", Proveedor.RazonSocial);
                cmd.Parameters.AddWithValue("@nit", Proveedor.Nit);
                cmd.Parameters.AddWithValue("@telefono", Proveedor.Telefono);
                cmd.Parameters.AddWithValue("@nroCuenta", Proveedor.NroCuentaBancaria);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Proveedor");
                cmd.Parameters.AddWithValue("@crud", "U");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Proveedor.IdProveedor + "Proveedor modificado");
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
            string query = "UPDATE Proveedor SET estado=0 WHERE idProveedor=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Proveedor.IdProveedor);

                //Ejecutamos el comando
                //Methods.ExecuteBasicCommand(cmd);
                Methods.ExecuteBasicCommandWithTransaction(cmd);

                string queryAuditoria = @"INSERT INTO Auditoria (tabla, crud, descripcion, idUsuario)
                                            VALUES (@tabla, @crud, @descripcion, @idUsuario)";
                cmd = null;
                cmd = Methods.CreateBasicCommand(queryAuditoria);
                cmd.Parameters.AddWithValue("@tabla", "Proveedor");
                cmd.Parameters.AddWithValue("@crud", "D");
                cmd.Parameters.AddWithValue("@descripcion", "ID=" + Proveedor.IdProveedor+ "Proveedor eliminado");
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
            string query = "SELECT * FROM vwProveedor ORDER BY 2";
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

        public Proveedor Get(short id)
        {
            Proveedor proveedor = null;

            string query = @"SELECT idProveedor, razonSocial, nitProveedor, telefono, nroCuentaBancaria, estado FROM Proveedor WHERE idProveedor = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    proveedor = new Proveedor(short.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), int.Parse(dr[4].ToString()), byte.Parse(dr[5].ToString()));
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

            return proveedor;
        }

        public DataTable SelectByIdName()
        {
            DataTable res = new DataTable();

            try
            {
                string query = "SELECT idProveedor, razonSocial FROM Proveedor WHERE estado = 1";

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
