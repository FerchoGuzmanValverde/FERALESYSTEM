using Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LimpiezaEmpleadoDAL
    {
        #region Metodos

        public static void Insert(LimpiezaEmpleado le)
        {
            string query = "INSERT INTO LimpiezaEmpleado (idEmpleado, idLimpieza) VALUES (@idEmpleado, @idLimpieza)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@idEmpleado", le.IdEmpleado);
                cmd.Parameters.AddWithValue("@idLimpieza", Methods.GetActIdTable("Limpieza"));

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update(LimpiezaEmpleado le)
        {
            string query = "UPDATE LimpiezaEmpleado SET idEmpleado = @idEmpleado WHERE idLimpieza = @idLimpieza";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@idEmpleado", le.IdEmpleado);
                cmd.Parameters.AddWithValue("@idLimpieza", le.IdLimpieza);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static LimpiezaEmpleado GetIdEmpleado(int idLimpieza)
        {
            LimpiezaEmpleado limpiezaEmpleado = null;

            string query = @"SELECT idLimpieza, idEmpleado FROM LimpiezaEmpleado WHERE idLimpieza = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", idLimpieza);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    limpiezaEmpleado = new LimpiezaEmpleado(int.Parse(dr[0].ToString()), int.Parse(dr[1].ToString()));
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

            return limpiezaEmpleado;
        }

        #endregion
    }
}
