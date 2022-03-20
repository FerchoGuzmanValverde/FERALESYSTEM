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
    public sealed class TipoProductoDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public TipoProducto TipoProducto { get; set; }

        public TipoProductoDAL()
        {

        }

        public TipoProductoDAL(TipoProducto TipoProducto)
        {
            this.TipoProducto = TipoProducto;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = "INSERT INTO TipoProducto (nombreTipo) VALUES (@nombre)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@nombre", TipoProducto.NombreTipo);

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
            string query = "UPDATE TipoProducto SET nombreTipo=@nombre WHERE idTipoProducto=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@nombre", TipoProducto.NombreTipo);
                cmd.Parameters.AddWithValue("@id", TipoProducto.IdTipoProducto);

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
            string query = "UPDATE TipoProducto SET estado=0 WHERE idTipoProducto=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", TipoProducto.IdTipoProducto);

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
            string query = "SELECT * FROM vwTipoProducto ORDER BY 2";
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

        public TipoProducto Get(byte id)
        {
            TipoProducto tipoProducto = null;

            string query = @"SELECT idTipoProducto, nombreTipo, estado FROM TipoProducto WHERE idTipoProducto = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    tipoProducto = new TipoProducto(byte.Parse(dr[0].ToString()), dr[1].ToString(), byte.Parse(dr[2].ToString()));
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

            return tipoProducto;
        }

        public DataTable SelectIdName()
        {
            DataTable res = new DataTable();

            try
            {
                string query = "SELECT idTipoProducto, nombreTipo FROM TipoProducto WHERE estado = 1";

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
