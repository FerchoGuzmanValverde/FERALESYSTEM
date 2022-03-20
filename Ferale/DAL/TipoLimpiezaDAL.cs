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
    public sealed class TipoLimpiezaDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public TipoLimpieza TipoLimpieza { get; set; }

        public TipoLimpiezaDAL()
        {

        }

        public TipoLimpiezaDAL(TipoLimpieza TipoLimpieza)
        {
            this.TipoLimpieza = TipoLimpieza;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = "INSERT INTO TipoLimpieza (tipoLimpieza) VALUES (@tipo)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@tipo", TipoLimpieza.NombreTipo);

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
            string query = "UPDATE TipoLimpieza SET tipoLimpieza=@tipo WHERE idTipoLimpieza=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@tipo", TipoLimpieza.NombreTipo);
                cmd.Parameters.AddWithValue("@id", TipoLimpieza.IdTipoLimpieza);

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
            string query = "UPDATE TipoLimpieza SET estado=0 WHERE idTipoLimpieza=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", TipoLimpieza.IdTipoLimpieza);

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
            string query = "SELECT * FROM vwTipoLimpieza ORDER BY 2";
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

        public TipoLimpieza Get(byte id)
        {
            TipoLimpieza tipoLimpieza = null;

            string query = @"SELECT idTipoLimpieza, tipoLimpieza, estado FROM TipoLimpieza WHERE idTipoLimpieza = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    tipoLimpieza = new TipoLimpieza(byte.Parse(dr[0].ToString()), dr[1].ToString(), byte.Parse(dr[2].ToString()));
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

            return tipoLimpieza;
        }

        public DataTable SelectIdName()
        {
            DataTable res = new DataTable();

            try
            {
                string query = "SELECT idTipoLimpieza, tipoLimpieza FROM TipoLimpieza WHERE estado = 1";

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
