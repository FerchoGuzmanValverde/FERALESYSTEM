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
    public sealed class AreaEmpresaDAL : OperacionesAbstractDAL
    {
        #region Atributos y Constructores

        public AreaEmpresa Area { get; set; }

        public AreaEmpresaDAL()
        {

        }

        public AreaEmpresaDAL(AreaEmpresa Area)
        {
            this.Area = Area;
        }

        #endregion

        #region Metodos

        public override void Insert()
        {
            string query = "INSERT INTO AreaEmpresa (areaEmpresa) VALUES (@area)";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@area", Area.NombreAreaEmpresa);

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
            string query = "UPDATE AreaEmpresa SET areaEmpresa=@nombre WHERE idAreaEmpresa=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@nombre", Area.NombreAreaEmpresa);
                cmd.Parameters.AddWithValue("@id", Area.IdAreaEmpresa);

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
            string query = "UPDATE AreaEmpresa SET estado=0 WHERE idAreaEmpresa=@id";
            SqlCommand cmd = null;
            try
            {
                cmd = Methods.CreateBasicCommand(query);

                //Los parametros
                cmd.Parameters.AddWithValue("@id", Area.IdAreaEmpresa);

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
            string query = "SELECT * FROM vwAreaEmpresa";
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

        public AreaEmpresa Get(byte id)
        {
            AreaEmpresa area = null;

            string query = @"SELECT idAreaEmpresa, areaEmpresa, estado FROM AreaEmpresa WHERE idAreaEmpresa = @id";

            SqlDataReader dr = null;
            SqlCommand cmd = null;

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    area = new AreaEmpresa(byte.Parse(dr[0].ToString()), dr[1].ToString(), byte.Parse(dr[2].ToString()));
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

            return area;
        }

        public DataTable SelectIdName()
        {
            DataTable res = new DataTable();

            string query = "SELECT idAreaEmpresa, areaEmpresa FROM AreaEmpresa WHERE estado = 1";
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
