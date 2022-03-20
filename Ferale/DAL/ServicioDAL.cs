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
    public sealed class ServicioDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public Servicio Servicio { get; set; }

        public ServicioDAL()
        {

        }

        public ServicioDAL(Servicio Servicio)
        {
            this.Servicio = Servicio;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = "INSERT INTO Servicio (servicio, unidadMedida) VALUES (@servicio, @unidadMedida)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@servicio", Servicio.NombreServicio);
                cmd.Parameters.AddWithValue("@unidadMedida", Servicio.UnidadMedida);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Update()
        {
            string query = "UPDATE Servicio SET servicio=@servicio, unidadMedida=@unidadMedida WHERE idServicio=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@servicio", Servicio.NombreServicio);
                cmd.Parameters.AddWithValue("@unidadMedida", Servicio.UnidadMedida);
                cmd.Parameters.AddWithValue("@id", Servicio.IdServicio);

                //Ejecutamos el comando
                Methods.ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Delete()
        {
            string query = "UPDATE Servicio SET estado=0 WHERE idServicio=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Servicio.IdServicio);

                //Ejecutamos el comando
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
            string query = "SELECT * FROM vwServicio ORDER BY 2";
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

        public Servicio Get(short id)
        {
            Servicio servicio = null;

            string query = @"SELECT idServicio, servicio, unidadMedida, estado FROM Servicio WHERE idServicio = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    servicio = new Servicio(short.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), byte.Parse(dr[3].ToString()));
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

            return servicio;
        }

        public DataTable SelectIdName()
        {
            DataTable res = new DataTable();

            string query = "SELECT idServicio, servicio FROM Servicio WHERE estado = 1";
            try
            {
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
