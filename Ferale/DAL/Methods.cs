using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DAL
{
    public class Methods
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["FeraleDBConnectionString"].ConnectionString;

        #region Creacion de SqlCommand

        public static SqlCommand CreateBasicCommand()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            return cmd;
        }

        public static SqlCommand CreateBasicCommand(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = connection;
            return cmd;
        }

        #endregion

        #region Ejecucion de Comandos

        public static void ExecuteBasicCommand(SqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public static void ExecuteBasicCommandWithTransaction(SqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                cmd.Transaction = cmd.Connection.BeginTransaction("Transaccion");
                cmd.ExecuteNonQuery();
                cmd.Transaction.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

        }

        public static DataTable ExecuteDataTableCommand(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return dt;
        }

        /// <summary>
        /// Es necesario cerrar la conexion del comando SqlCommand
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteDataReaderCommand(SqlCommand cmd)
        {
            SqlDataReader dr = null;
            try
            {
                cmd.Connection.Open();
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dr;
        }

        /// <summary>
        /// consigue el ultimo id de una tabla
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public static int GetActIdTable(string tabla)
        {
            int res = -1;
            string query = "SELECT IDENT_CURRENT('" + tabla + "')";
            try
            {
                SqlCommand cmd = CreateBasicCommand(query);
                res = int.Parse(ExcecuteScalarCommand(cmd));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        /// <summary>
        /// comand scalar
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string ExcecuteScalarCommand(SqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                return cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        #endregion
    }
}
